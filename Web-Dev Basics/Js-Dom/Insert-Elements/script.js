const button = document.createElement('button')
button.innerHTML = "Add Item"
console.log(button);

const h1 = document.createElement('h1')
h1.innerHTML = "Welcome to the team."

const div = document.querySelector(".main")
div.before(h1)
// div.append(button)
// div.prepend(button)
// div.appendChild(button)
// div.before(button)
div.after(button)

// to remove 
h1.remove()
