// selecting DOM Elements and Manipulate it ....
let title = document.getElementById("title");
console.log(title.innerText);
console.log(title.innerHTML);
console.log(title.id);
console.log(title.className);

// Styling using js ....
title.style.backgroundColor = "green";
title.style.border = `3px solid white`;
title.style.paddingLeft = `10px`;

// Imp : diffrence in InnerText and TextContent
let info = document.getElementById("info");
console.log("Info Id : " + info.id);

console.log("Using InnerText : ", info.innerText);
console.log("Using TextConten : ", info.textContent);
console.log("Using InnerHtml : ", info.innerHTML);

// Query Selector
console.log("use of Query Selector");
let firstH1 = document.querySelector("h1");
let AllH1 = document.querySelectorAll("h1");
console.log("FirstH1 = ", firstH1);
console.log("All H1 : ", AllH1);

// working with list
const listData = document.getElementsByClassName("list");
console.log(listData);

// converting HtmlCollection Type into Array , so we can perform forEach and map function
const convertedArray = Array.from(listData);
console.log(convertedArray);

// changing properties by iterate over li data 
convertedArray.forEach(function (li) {
  li.style.color = "orange";
});
