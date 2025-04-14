// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
document.addEventListener('DOMContentLoaded', function () {

    // Handle navbar transparency on scroll
    const navbar = document.querySelector('.navbar');

    function handleNavbarTransparency() {
        if (window.scrollY > 50) {
            navbar.style.padding = "0.75rem 0";
            navbar.style.boxShadow = "0 4px 10px rgba(0, 0, 0, 0.1)";
        } else {
            navbar.style.padding = "1rem 0";
            navbar.style.boxShadow = "0 4px 6px -1px rgba(0, 0, 0, 0.1)";
        }
    }

    window.addEventListener('scroll', handleNavbarTransparency);
    handleNavbarTransparency(); // Initial call

    // Handle smooth scrolling for anchor links
    document.querySelectorAll('a[href^="#"]').forEach(anchor => {
        anchor.addEventListener('click', function (e) {
            e.preventDefault();

            const targetId = this.getAttribute('href');

            if (targetId === "#") return;

            const targetElement = document.querySelector(targetId);

            if (targetElement) {
                window.scrollTo({
                    top: targetElement.offsetTop - 80, // Adjust for navbar height
                    behavior: 'smooth'
                });

                // Close mobile menu if open
                const navbarCollapse = document.querySelector('.navbar-collapse');
                if (navbarCollapse.classList.contains('show')) {
                    document.querySelector('.navbar-toggler').click();
                }
            }
        });
    });

    // Form validation
    const contactForm = document.querySelector('.contact-form');

    if (contactForm) {
        contactForm.addEventListener('submit', function (e) {
            e.preventDefault();

            let isValid = true;
            const name = document.getElementById('name');
            const email = document.getElementById('email');
            const subject = document.getElementById('subject');
            const message = document.getElementById('message');

            // Simple validation
            if (name.value.trim() === '') {
                isValid = false;
                highlightField(name, true);
            } else {
                highlightField(name, false);
            }

            if (email.value.trim() === '' || !isValidEmail(email.value)) {
                isValid = false;
                highlightField(email, true);
            } else {
                highlightField(email, false);
            }

            if (subject.value.trim() === '') {
                isValid = false;
                highlightField(subject, true);
            } else {
                highlightField(subject, false);
            }

            if (message.value.trim() === '') {
                isValid = false;
                highlightField(message, true);
            } else {
                highlightField(message, false);
            }

            if (isValid) {
                // Simulate form submission
                const submitBtn = contactForm.querySelector('button[type="submit"]');
                const originalText = submitBtn.innerHTML;

                submitBtn.disabled = true;
                submitBtn.innerHTML = '<i class="bi bi-hourglass-split me-2"></i>Sending...';

                // Simulate API call delay
                setTimeout(() => {
                    submitBtn.innerHTML = '<i class="bi bi-check-circle me-2"></i>Sent Successfully!';
                    submitBtn.classList.remove('btn-primary');
                    submitBtn.classList.add('btn-success');

                    contactForm.reset();

                    // Reset button after 3 seconds
                    setTimeout(() => {
                        submitBtn.innerHTML = originalText;
                        submitBtn.classList.remove('btn-success');
                        submitBtn.classList.add('btn-primary');
                        submitBtn.disabled = false;
                    }, 3000);
                }, 1500);
            }
        });
    }

    // Helper functions
    function highlightField(field, isError) {
        if (isError) {
            field.classList.add('is-invalid');
        } else {
            field.classList.remove('is-invalid');
            field.classList.add('is-valid');
        }
    }

    function isValidEmail(email) {
        const regex = /^[^\s@]+@[^\s@]+\.[^\s@]+$/;
        return regex.test(email);
    }

    // Animation on scroll for features
    const featureCards = document.querySelectorAll('.feature-card');

    const observerOptions = {
        threshold: 0.1,
        rootMargin: '0px 0px -100px 0px'
    };

    const observer = new IntersectionObserver((entries) => {
        entries.forEach(entry => {
            if (entry.isIntersecting) {
                entry.target.classList.add('animate__animated', 'animate__fadeInUp');
                observer.unobserve(entry.target);
            }
        });
    }, observerOptions);

    featureCards.forEach(card => {
        observer.observe(card);
    });
});

