(function startCountdown() {
    let timer = document.getElementById('timer');
    let time = timer.innerText;
    //сюда же написать сбор ответов и пересылку их на страницу с результатами
    if (time == 0) {
        let answers = document.getElementsByClassName("answer").innerText;
        $.post('/Pages/TestResults.cshtml', { answers: answers });
        alert("Время истекло");
        location.href = '/Pages/TestResults.cshtml';
    } else { timer.innerText--; }

    setTimeout(startCountdown, 1000);
}());