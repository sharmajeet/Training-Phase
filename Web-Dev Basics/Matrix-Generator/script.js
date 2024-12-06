var rowsInput = document.getElementById("rows");
var columnsInput = document.getElementById("columns");
var generateBtn = document.getElementById("generate-btn");
var resultBtn = document.getElementById("result-btn");
var matrixContainer = document.getElementById("matrix-container");
var resultDiv = document.getElementById("result");

// actual click function

generateBtn.addEventListener("click", function () {
  matrixContainer.innerHTML = " ";

  var rows = parseInt(rowsInput.value);
  var columns = parseInt(columnsInput.value);

  // creating matrixx
  for (var i = 0; i < rows; i++) {
    for (j = 0; j < columns; j++) {
      var input = document.createElement("input");
      input.type = "number";
      input.className = "matrix-input";
      input.id = "matrix-" + i + "-" + j;
      matrixContainer.appendChild(input);
    }

    // break
    var breakLine = document.createElement("div");
    breakLine.style.width = "100%";
    matrixContainer.appendChild(breakLine);
  }
});

// button click function

resultBtn.addEventListener("click", function () {
  var rows = parseInt(rowsInput.value);
  var columns = parseInt(columnsInput.value);

  var matrix = [];

  for (var i = 0; i < rows; i++) {
    var rowValues = [];
    for (var j = 0; j < columns; j++) {
      var value =
        parseInt(document.getElementById("matrix-" + i + "-" + j).value) || 0;
      rowValues.push(value);
    }
    matrix.push(rowValues);
  }

  // highest value
  var highestValue = -Infinity;
  var highestRowIndex = -1;
  var highestColIndex = -1;

  for (var i = 0; i < rows; i++) {
    for (var j = 0; j < columns; j++) {
      if (matrix[i][j] > highestValue) {
        highestValue = matrix[i][j];
        highestRowIndex = i;
        highestColIndex = j;
      }
    }
  }

  // Left and right value
  var leftValue =
    highestColIndex > 0 ? matrix[highestRowIndex][highestColIndex - 1] : "-";
  var rightValue =
    highestColIndex < columns - 1
      ? matrix[highestRowIndex][highestColIndex + 1]
      : "-";

  // Display the result
  resultDiv.innerHTML = `
  <h3>Maximum Value:</h3>
  <p>Value: ${highestValue}</p>
  <p>Left: ${leftValue}, Right: ${rightValue}</p>
`;
});
