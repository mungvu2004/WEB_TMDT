document.addEventListener("DOMContentLoaded", function () {
    const SliderImg = document.querySelectorAll('.slider_img img');
    const SliderDot = document.querySelectorAll('.slider_dot span');
    const SliderLength = SliderImg.length;
    var curenIndex = 0;

    function ImgNext(index) {
        SliderImg.forEach(img => img.classList.remove('display_block'));
        SliderImg[index].classList.add('display_block');
        SliderDot.forEach(dot => dot.classList.remove('slider-span'));
        SliderDot[index].classList.add('slider-span');
        curenIndex = index;
    }
    function ImgNextDot() {
        ImgNext((curenIndex + 1) % SliderLength);
    }
    SliderDot.forEach((dot, index) => {
        dot.addEventListener('click', function () {
            ImgNext(index);
        });
    });

    setInterval(ImgNextDot, 5000);

});