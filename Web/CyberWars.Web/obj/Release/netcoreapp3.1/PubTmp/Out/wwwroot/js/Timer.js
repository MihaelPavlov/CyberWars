function timer(x) {
    var time = x; // This is the time allowed
    var saved_countdown = localStorage.getItem('saved_countdown');

    if (saved_countdown == null) {
        // Set the time we're counting down to using the time allowed
        var new_countdown = new Date().getTime() + (time + 2) * 1000;

        time = new_countdown;
        localStorage.setItem('saved_countdown', new_countdown);
    } else {
        time = saved_countdown;
    }

    // Update the count down every 1 second
    var x = setInterval(() => {

        // Get today's date and time
        var now = new Date().getTime();

        // Find the distance between now and the allowed time
        var distance = time - now;

        // Time counter
        // var counter = Math.floor((distance % (1000 * 60 * 30)) / 1000);
        var minutes = Math.floor((distance % (1000 * 60 * 60)) / (1000 * 60));
        var seconds = Math.floor((distance % (1000 * 60)) / 1000);
        // Output the result in an element with id="demo"
        document.getElementById("button").innerHTML = minutes + " m :" + seconds + " s";

        // If the count down is over, write some text
        if (minutes <= 0 && seconds <= 0) {
            clearInterval(x);
            localStorage.removeItem('saved_countdown');
            document.getElementById("demo").innerHTML = "EXPIRED";
        }
    }, 1000);
}

var btn = document.getElementById("button");
var interval;

btn.addEventListener("mouseover", function () {
    if (!interval)
        interval = setInterval(timer(1200), 500);
});

//function switchfunction() {
//    if (document.body.style.background === 'red') {
//        document.body.style.background = 'green';
//    } else {
//        document.body.style.background = 'red';
//    }
//}