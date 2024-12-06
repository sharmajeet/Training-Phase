$(document).ready(function () {

  function showtime() {

    const data = new Date();
    const hours = data.getHours();
    const minutes = data.getMinutes();
    const seconds = data.getSeconds();
    const day = data.getDate();
    const month = data.getMonth();
    const year = data.getFullYear();


    $('#hour').text(hours);
    $('#minute').text(minutes);
    $('#second').text(seconds);

    $("#day").text(day);
    $("#month").text(month);
    $("#year").text(year);

  }
  
  setInterval(showtime, 1000);
  showtime()
});
  