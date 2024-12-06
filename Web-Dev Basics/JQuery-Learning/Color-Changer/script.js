const buttons = document.querySelectorAll('.btn');
const body = document.querySelector('body');

buttons.forEach((button) => {
    button.addEventListener('click', () => {
        let data = button.innerText.toLowerCase();
        body.style.backgroundColor = `${data}`;
    });
});