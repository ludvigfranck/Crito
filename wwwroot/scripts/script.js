function Slider(containerSelector, prevButtonId, nextButtonId) {
    const itemsWrapper = document.querySelector(containerSelector);
    const prevBtn = document.getElementById(prevButtonId);
    const nextBtn = document.getElementById(nextButtonId);

    if (!itemsWrapper || !prevBtn || !nextBtn) {
        return;
    }

    let index = 0;
    const itemsPerSlide = 3;
    const totalItems = itemsWrapper.querySelectorAll('.item-card');

    if (totalItems.length != 0) {
        const itemWidth = totalItems[0].offsetWidth + 30;

        prevBtn.addEventListener('click', () => {
            if (index > 0) {
            index--;
            updateSlide();
            }
        });
    
        nextBtn.addEventListener('click', () => {
            if (index < totalItems.length - itemsPerSlide) {
                index++;
                updateSlide();
            }
        });

        function updateSlide() {
            itemsWrapper.style.transform = `translateX(-${index * itemWidth}px)`;
        }
    }
    else {
        console.log("No items found...")
    }
}

document.addEventListener('DOMContentLoaded', function() {
    if (document.querySelector('.articles')) {
        console.log("Init home slider")
        Slider('.articles-wrapper', 'articles-prev-btn', 'articles-next-btn');
    }

    if (document.querySelector('.all-services')) {
        console.log("Init services slider")
        Slider('.projects-wrapper', 'projects-prev-btn', 'projects-next-btn');
        Slider('.features-wrapper', 'features-prev-btn', 'features-next-btn');
    }

    if (document.querySelector('.services-slider')) {
        console.log("Init services slider");
        Slider('.services-wrapper', 'services-prev-btn', 'services-next-btn');
    }
});
