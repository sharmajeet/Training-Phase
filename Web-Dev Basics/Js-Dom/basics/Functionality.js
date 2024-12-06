function addLanguage(langName) {
  const li = document.createElement("li");
  li.innerText = `${langName}`;
  document.querySelector(".language").appendChild(li);
}
addLanguage("python");
addLanguage("Ruby");

// same functionality in optimize way

function optimalAddLan(addLang) {
  const li = document.createElement("li");
  const addText = document.createTextNode(addLang);
  li.appendChild(addText);
  document.querySelector(".language").appendChild(li);
}
optimalAddLan("c++");
optimalAddLan("yaml");


function optimal(addItem) { 
    const li = document.createElement('li');
    const add  = document.createTextNode(addItem);
    li.appendChild(add);

    document.querySelector('.language').appendChild(li)
}
optimal("hii")