function interpolalinear(x, y, value) {
  // Check if the given value is out of the range of x values
  if (value > Math.max.apply(Math, x) || value < Math.min.apply(Math, x)) {
    throw "value can't be interpolated !!";
    return;
  }

  // Initialize variables for finding the closest points for interpolation
  var check = 0, index;

  // Loop through the x array to find the closest point to the given value
  for (var i = 0, iLen = x.length; i < iLen; i++) {
    if (x[i][0] == value) {
      // If an exact match is found, return the corresponding y value
      return y[i][0];
    } else {
      // If the current x value is closer to the given value than the previous one, update the index
      if (x[i][0] < value && ((x[i][0] - check) < (value - check))) {
        check = x[i][0];
        index = i;
      }
    }
  }

  // After finding the closest point, perform linear interpolation
  var xValue, yValue, xDiff, yDiff, xInt;
  yValue = y[index][0];
  xDiff = x[index + 1][0] - check;
  yDiff = y[index + 1][0] - yValue;
  xInt = value - check; 

  // Perform linear interpolation and return the result
  return (xInt * (yDiff / xDiff)) + yValue;
}
