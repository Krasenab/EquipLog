//lottie.loadAnimation(
//    {
//    container: document.getElementById('heroLottie'),
//    renderer: 'svg',
//    loop: true,
//    autoplay: true,
//    path: 'https://assets9.lottiefiles.com/packages/lf20_w51pcehl.json' // or another animation URL  хттпс//assets9.lottiefiles.com/packages/lf20_w51pcehl.json
//    }
//);

//lottie.loadAnimation({

//        container: document.getElementById('createAnimation'),
//        renderer: 'svg',
//        loop: true,
//        autoplay: true,
//        path: 'https://assets4.lottiefiles.com/packages/lf20_ytflfgrt.json'

//});

document.addEventListener("DOMContentLoaded", function () {
  

    const heroContainer = document.getElementById('heroLottie');
    if (heroContainer) {
        console.log("Found heroLottie");
        lottie.loadAnimation({
            container: heroContainer,
            renderer: 'svg',
            loop: true,
            autoplay: true,
            path: 'https://assets9.lottiefiles.com/packages/lf20_w51pcehl.json'
        });
    }
});
document.addEventListener("DOMContentLoaded", function () {
    console.log("Lottie script loaded");
    const createContainer = document.getElementById('createAnimation');
    if (createContainer) {
        lottie.loadAnimation({
            container: createContainer,
            renderer: 'svg',
            loop: true,
            autoplay: true,
            path: 'https://assets1.lottiefiles.com/packages/lf20_q5pk6p1k.json'
        });
    }
});