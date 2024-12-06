$(document).ready(function () {
  $(".box").fadeOut();
  $(".box").fadeIn();

  //   Animation

  $(".box").animate({ opacity: 0.3 }, 1000);
  $(".box").animate({ opacity: 0.9 }, 300);
  $(".box").animate({ height: "300px" }, 1000);
  $(".box").animate({ width: "300px" }, 1000);

  //   Adiding Css properties
  $(".box").css("background-color", "gray");
});
