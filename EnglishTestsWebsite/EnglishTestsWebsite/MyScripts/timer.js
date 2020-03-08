(function startCountdown() {
    let timer = document.getElementById('timer');
    let time = timer.innerText;

    if (time == 0) {
        let answers = document.getElementsByClassName("answer").innerText;
        $.post('/Pages/TestResults.cshtml', { answers: answers });
        alert("Время истекло");
    } else { timer.innerText--; }

    setTimeout(startCountdown, 1000);
}());