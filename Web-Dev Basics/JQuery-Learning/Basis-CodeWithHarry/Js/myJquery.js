// syntax of jquery is  : $('selector').action();
$(document).ready(function () {
  // write your jquery here...

  $("p").click(function () {
    console.log("clicked");
  });

  $("p").dblclick(function () {
    $(this).hide();
  });

  // Selectors is JQuery

  // 1st - element selector
  $("p").hover(function () {
    console.log(`hover on ${this}`);
  });

  // 2nd - id selector
  $("#second").click(function () {
    console.log("id selector is clicked");
  });

  // 3rd - class selector
  $(".class").click(function () {
    console.log("Class selector is clicked");
  });

  // Other selectors
  $("*").click(function () {
    console.log("Clicked to alll");
  });

  //   Events in JQuery - single event
  $("p").dblclick(function () {
    console.log("Double Clicked on P.");
  });

  //   Event - multiple event
  $("button").on({
    click: function () {
      console.log("Button Clicked.");
    },
    mouseleave: function () {
      console.log("mouse leave");
    },
  });

  //   Show and Hide Methods

  //   $("button").hover(function () {
  //     $("button").hide();
  //     console.log("On hover we hide the button");
  //   });

  //   $("#wiki").hide(1000, function () {
  //     $("#wiki").show(1000);
  //   });

  $("#btn").click(function () {
    $("#wiki").toggle(1000);
  });
});
