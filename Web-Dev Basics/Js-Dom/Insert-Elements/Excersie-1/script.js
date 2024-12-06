const button = document.createElement("button");
button.style.backgroundColor = "red";
button.style.color = "white";
button.style.fontSize = "20px";
button.style.height = "40px";
button.style.width = "100px";
button.innerHTML = "Click Me!";

const body = document.querySelector("body").prepend(button);

const newEle = document.querySelector("h1");
console.log(newEle.classList);
newEle.classList.add("main");
console.log(newEle.classList);

console.log(newEle.getAttribute("class"));

