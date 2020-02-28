(function startCountdown() {
    let timer = document.getElementById('timer');
    let time = timer.innerText;
    //сюда же написать сбор ответов и пересылку их на страницу с результатами
    if (time == 0) {
        alert("Время истекло");
        location.href = '../TestResults.cshtml';
    } else { timer.innerText--; }

    setTimeout(startCountdown, 1000);
}());