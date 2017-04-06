$(function () {
    $("#photoartsystem-owl-carousel").owlCarousel({
        margin: 5,        
        rewind: true,
        controlsClass: 'owl-controls',
        navText: ['<i class="fa fa-arrow-left" aria-hidden="true"></i>', '<i class="fa fa-arrow-right" aria-hidden="true"></i>'],
        responsiveClass: true,
        responsive: {
            0: {
                items: 1,                
                nav: true,
                dots: false
            },
            550: {
                items: 2,
                nav: true,
                dots: false
            },
            770: {
                items: 3,                
                nav: true,
                dots: false
            },
            995: {
                items: 4,
                nav: true,
                loop: false,
                dots: false
            }
        }
    });
})
