
$(document).ready(function () {

    $("#generate-btn").click(function () {

        const length = $("#length").val();
        const uppercase = $("#uppercase").is(":checked");
        const lowercase = $("#lowercase").is(":checked");
        const numbers = $("#numbers").is(":checked");
        const symbols = $("#symbols").is(":checked");

        var password = "";
        var dataSet = "";

        if (uppercase) {
            dataSet += "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        }
        if (lowercase) {
            dataSet += "abcdefghijklmnopqrstuvwxyz";
        }
        if (numbers) {
            dataSet += "0123456789";
        }
        if (symbols) {
            dataSet += "!@#$%^&*()_+";
        }

        console.log(dataSet);

        for (let i = 0; i < length; i++) {
            password += dataSet.charAt(Math.floor(Math.random() * dataSet.length));
        }

        $("#password").val(password);

        $("#copy-btn").click(function () {
            $("#password").select();
            document.execCommand("copy");
            $("#copy-btn").text("Copied!");
            $("#copy-btn").css("background-color", "green");

        });


        $(".settings p").remove();

        if (
            length >= 8 &&
            uppercase &&
            lowercase &&
            numbers &&
            symbols
        ) {
            $("div.settings").prepend("<p class='text-success'>Password is strong!</p>");
            $(".text-success").css("color", "green");
        } else if (
            length >= 8 &&
            uppercase &&
            lowercase &&
            numbers
        ) {
            $("div.settings").prepend("<p class='text-pass'>Password Generated!</p>");
            $(".text-pass").css("color", "blue");
        } else if (
            length >= 8 &&
            uppercase &&
            lowercase
        ) {
            $("div.settings").prepend("<p class='text-warning'>Password is weak!</p>");
            $(".text-warning").css("color", "yellow");
        } else {
            $("div.settings").prepend("<p class='text-danger'>Password is very weak!</p>");
            $(".text-danger").css("color", "red");
        }

    });



});