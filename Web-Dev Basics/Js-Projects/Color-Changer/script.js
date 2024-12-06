// Select all buttons with the id 'btn'
const colorEle = document.querySelectorAll("#btn");

// Loop over each button and add a click event listener
colorEle.forEach(function (button) {
  button.addEventListener("click", function (e) {
    // Get the button's id, which corresponds to the color name
    const color = e.target.id;

    // Check if the color is valid and change the background color
    if (["Gray", "Red", "Orange", "Blue"].includes(color)) {
      document.body.style.backgroundColor = color.toLowerCase();
    }
  });
});
