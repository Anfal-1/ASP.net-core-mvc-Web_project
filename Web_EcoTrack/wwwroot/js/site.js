document.addEventListener("DOMContentLoaded", function () {
    // تمرير سلس عند النقر على الروابط
    document.querySelectorAll('nav a, .btn').forEach(anchor => {
        anchor.addEventListener('click', function (e) {
            if (this.getAttribute('href').startsWith('#')) {
                e.preventDefault();
                const targetId = this.getAttribute('href').substring(1);
                const targetElement = document.getElementById(targetId);
                if (targetElement) {
                    window.scrollTo({
                        top: targetElement.offsetTop - 50,
                        behavior: "smooth"
                    });
                }
            }
        });
    });

    // تغيير لون الشريط العلوي عند التمرير
    window.addEventListener("scroll", function () {
        let navbar = document.querySelector("nav");
        if (window.scrollY > 50) {
            navbar.style.background = "#4d3c2d";
        } else {
            navbar.style.background = "#6c543b";
        }
    });
});
