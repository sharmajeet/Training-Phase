const parentData = document.querySelector(".parent");
console.log(parentData);

console.log(parentData.children);
console.log(parentData.children[1].innerHTML);

for (let i = 0; i < parentData.children.length; i++) {
  console.log("Day : " + `${parentData.children[i].innerHTML}`);
}

const dyaOne = document.querySelector(".days");
console.log(dyaOne.parentElement);
console.log(dyaOne.nextElementSibling.innerText);
console.log("Nodes : ", parentData.childNodes);

// Creating new element using js

const div = document.createElement("div");
div.className = "main";
div.style.backgroundColor = `#212121`;
div.style.color = "white";

div.setAttribute("title", "div for general usecase");

// Imp concept
// div.innerText = "JeetSharma"
// innerText is very costly operation in terms of time so we generally use CreateTextNode() ...

// Most prefferd way ..
const addText = document.createTextNode("Jeet Sharma");
div.appendChild(addText);
console.log(addText);
