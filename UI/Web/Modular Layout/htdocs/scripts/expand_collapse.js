
addLoadListener(initExpandCollapse);




function initExpandCollapse()
{
	var modules = [document.getElementById("modules1"), document.getElementById("modules2")];
	
	for (var i in modules)
	{
		var h2s = modules[i].getElementsByTagName("h2");

		for (var i = 0; i < h2s.length; i++)
		{
			var newA = document.createElement("a");
			newA.setAttribute("href", "#");
			newA.setAttribute("title", "Expand/Collapse");
			attachEventListener(newA, "mousedown", mousedownExpandCollapse, false);
			newA.onclick = clickExpandCollapse;
			
				var newImg = document.createElement("img");
				newImg.setAttribute("src", "images/expand_collapse.gif");
				newImg.setAttribute("alt", "Expand/Collapse");
				newA.appendChild(newImg);
				
			h2s[i].appendChild(newA);
		}
	}
	
	return true;
};




function mousedownExpandCollapse(event)
{
	if (typeof event == "undefined")
	{
		event = window.event;
	}
	
	if (typeof event.stopPropagation != "undefined")
	{
		event.stopPropagation();
	}
	else
	{
		event.cancelBubble = true;
	}
	
	return true;
};




function clickExpandCollapse()
{
	if (!hasClass(this.parentNode.parentNode, "collapsed"))
	{
		addClass(this.parentNode.parentNode, "collapsed");
	}
	else
	{
		removeClass(this.parentNode.parentNode, "collapsed");
	}
	
	return false;
};