const form = document.querySelector("form");

form.addEventListener("submit", function (e) {
  e.preventDefault();

  const heightVal = parseInt(document.querySelector("#height").value);
  const weightVal = parseInt(document.querySelector("#weight").value);

  const results = document.querySelector("#results");

  if (heightVal === "" || heightVal < 0 || isNaN(heightVal)) {
    results.innerHTML = "Please enter a valid height.";
  } else if (weightVal === "" || weightVal < 0 || isNaN(weightVal)) {
    results.innerHTML = "Please enter a valid weight.";
  } else {
    const bmi = (weightVal / ((heightVal * heightVal)/10000)).toFixed(2)
    results.innerHTML = `<span>BMI Result is  : ${bmi}</span>`
  }

  console.log(heightVal);
  console.log(weightVal);
  console.log(results);
});
