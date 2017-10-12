function ClickHeaderInGrid()
{
	var counA = document.getElementById("ctrGrid_RadGridStyles_ctl00").getElementsByTagName("tr")[1].getElementsByTagName("a");
	for(var i=0;i<counA.length;i++)
	{
			counA[i].click();
			setTimeout(ClickHeaderInGrid, 2000);
	}
}