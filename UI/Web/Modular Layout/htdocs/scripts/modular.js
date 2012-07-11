
addLoadListener(initModular);




function initModular()
{
	var modules = [document.getElementById("modules1"), document.getElementById("modules2")];
	
	for (var i = 0; i < modules.length; i++)
	{
		var h2s = modules[i].getElementsByTagName("h2");

		for (var j = 0; j < h2s.length; j++)
		{
			addClass(h2s[j].parentNode, "moduleDraggable");
			attachEventListener(h2s[j], "mousedown", mousedownH2, false);
		}
	}
	
	return true;
};




function mousedownH2(event)
{
	if (typeof event == "undefined")
	{
		event = window.event;
	}
	
	if (typeof event.target != "undefined")
	{
		dragTarget = event.target.parentNode;
	}
	else
	{
		dragTarget = event.srcElement.parentNode;
	}

	dragOrigin = [event.clientX, event.clientY];
	dragHotspots = [];

	var modules = [document.getElementById("modules1"), document.getElementById("modules2")];
	
	for (var i = 0; i < modules.length; i++)
	{
		var divs = modules[i].getElementsByTagName("div");

		for (var j = 0; j < divs.length; j++)
		{
			if (divs[j] != null && hasClass(divs[j], "module"))
			{
				var modulePosition = getPosition(divs[j]);

				dragHotspots[dragHotspots.length] =
				{
					element: divs[j],
					offsetX: modulePosition[0],
					offsetY: modulePosition[1]
				}
			}
		}
		
		var modulePosition = getPosition(modules[i]);
		
		dragHotspots[dragHotspots.length] =
		{
			element: modules[i],
			offsetX: modulePosition[0],
			offsetY: modulePosition[1] + modules[i].offsetHeight
		}
	}
	
	var position = getPosition(dragTarget);
	
	var ghost = document.createElement("div");
	ghost.setAttribute("id", "ghost");
	document.getElementsByTagName("body")[0].appendChild(ghost);

	ghost.appendChild(dragTarget.cloneNode(true));
	ghost.style.left = position[0] + "px";
	ghost.style.top = position[1] + "px";
	
	attachEventListener(document, "mousemove", mousemoveDocument, false);
	attachEventListener(document, "mouseup", mouseupDocument, false);
	
	event.returnValue = false;

	if (typeof event.preventDefault != "undefined")
	{
		event.preventDefault();
	}

	return true;
};




function mousemoveDocument(event)
{
	if (typeof event == "undefined")
	{
		event = window.event;
	}
	
	var ghost = document.getElementById("ghost");
	
	if (ghost != null)
	{
		ghost.style.marginLeft = event.clientX - dragOrigin[0] + "px";
		ghost.style.marginTop = event.clientY - dragOrigin[1] + "px";
	}
	
	var closest = null;
	var closestY = null;
	
	for (var i in dragHotspots)
	{
		var ghostX = parseInt(ghost.style.left, 10) + parseInt(ghost.style.marginLeft, 10);
		var ghostY = parseInt(ghost.style.top, 10) + parseInt(ghost.style.marginTop, 10);
		
		if (ghostX >= dragHotspots[i].offsetX - ghost.offsetWidth && ghostX <= dragHotspots[i].offsetX + dragHotspots[i].element.offsetWidth)
		{
			var distanceY = Math.abs(ghostY - dragHotspots[i].offsetY);
			
			if (closestY == null || closestY > distanceY)
			{
				closest = dragHotspots[i];
				closestY = distanceY;
			}
		}
	}
	
	if (closest != null)
	{
		var ghostMarker = document.getElementById("ghostMarker");
		
		if (ghostMarker == null)
		{
			ghostMarker = document.createElement("div");
			ghostMarker.id = "ghostMarker";
			document.getElementsByTagName("body")[0].appendChild(ghostMarker);
		}
		
		ghostMarker.marked = closest.element;
		
		ghostMarker.style.left = closest.offsetX + "px";
		ghostMarker.style.top = closest.offsetY + "px";
	}
	else
	{
		var ghostMarker = document.getElementById("ghostMarker");
		
		if (ghostMarker != null)
		{
			ghostMarker.parentNode.removeChild(ghostMarker);
		}
		
	}
	
	event.returnValue = false;

	if (typeof event.preventDefault != "undefined")
	{
		event.preventDefault();
	}

	return true;
};




function mouseupDocument()
{
	detachEventListener(document, "mousemove", mousemoveDocument, false);
	
	var ghost = document.getElementById("ghost");
	
	if (ghost != null)
	{
		ghost.parentNode.removeChild(ghost);
	}
	
	var ghostMarker = document.getElementById("ghostMarker");
	
	if (ghostMarker != null)
	{
		if (!hasClass(ghostMarker.marked, "module"))
		{
			ghostMarker.marked.appendChild(dragTarget);
		}
		else
		{
			ghostMarker.marked.parentNode.insertBefore(dragTarget, ghostMarker.marked);
		}
		
		ghostMarker.parentNode.removeChild(ghostMarker);
	}
	
	return true;
};




function getPosition(theElement)
{
	var positionX = 0;
	var positionY = 0;

	while (theElement != null)
	{
		positionX += theElement.offsetLeft;
		positionY += theElement.offsetTop;
		theElement = theElement.offsetParent;
	}

	return [positionX, positionY];
};