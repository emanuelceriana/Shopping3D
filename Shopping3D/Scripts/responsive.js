function myFunction(x,y) {
    if (x.matches) { // If media query matches

        document.getElementByClass("imageTd").style.display = "";
        document.getElementByClass("imageTh").style.display = "";
        document.getElementByClass("totalTd").style.display = "";
        document.getElementByClass("totalTh").style.display = "";

    } else if (y.matches && !x.matches) {
        console.log("hola");
        document.getElementByClass("imageTd").style.display = "none";
        document.getElementByClass("imageTh").style.display = "none";

    } else {
        console.log("hola2");
        document.getElementByClass("imageTd").style.display = "none";
        document.getElementByClass("imageTh").style.display = "none";
        document.getElementByClass("totalTd").style.display = "none";
        document.getElementByClass("totalTh").style.display = "none";
    }
}

var x = window.matchMedia("(min-width: 701px)")
var y = window.matchMedia("(min-width: 376px)")
myFunction(x,y) // Call listener function at run time

