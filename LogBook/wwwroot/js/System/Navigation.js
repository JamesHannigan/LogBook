const navItems = document.querySelectorAll('.nav-item');
const underline = document.querySelector('.underline');
const activeItem = document.querySelector('.active');

document.addEventListener('DOMContentLoaded', function () {
    if (activeItem) {
        defaultUnderline();
    }

    navItems.forEach(item => {
        item.addEventListener('mouseenter', () => moveUnderline(item));
        item.addEventListener('mouseleave', () => moveUnderline(activeItem));
        item.addEventListener('click', function () {
            document.querySelector('.nav-item.active').classList.remove('active');
            this.classList.add('active');
            moveUnderline(this);
        });
    });

});

window.addEventListener('resize', defaultUnderline);

function defaultUnderline() {
    moveUnderline(activeItem);
}

function moveUnderline(item) {
    const itemRect = item.getBoundingClientRect();
    const navRect = item.closest('nav').getBoundingClientRect();

    underline.style.width = `${itemRect.width}px`;
    underline.style.left = `${itemRect.left - navRect.left}px`;
}