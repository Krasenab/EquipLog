document.addEventListener('DOMContentLoaded', function () {

    // Toggle sidebar on mobile
    const toggleSidebarBtn = document.getElementById('toggleSidebar');
    const closeSidebarBtn = document.getElementById('closeSidebar');
    const sidebar = document.getElementById('sidebar');

    if (toggleSidebarBtn && sidebar) {
        toggleSidebarBtn.addEventListener('click', function () {
            sidebar.classList.toggle('show');
        });
    }

    if (closeSidebarBtn && sidebar) {
        closeSidebarBtn.addEventListener('click', function () {
            sidebar.classList.remove('show');
        });
    }

    // Add active class to current menu item (for demo purposes)
    const sidebarMenuLinks = document.querySelectorAll('.sidebar-menu-link');

    sidebarMenuLinks.forEach(link => {
        link.addEventListener('click', function (e) {
            // Only prevent default if it's a # link
            if (link.getAttribute('href') === '#') {
                e.preventDefault();
            }

            // Remove active class from all links
            sidebarMenuLinks.forEach(l => l.classList.remove('active'));

            // Add active class to clicked link
            link.classList.add('active');
        });
    });

    // Animate the stats numbers counting up
    const statsNumbers = document.querySelectorAll('.stats-number');

    function animateValue(element, start, end, duration) {
        let startTimestamp = null;
        const step = (timestamp) => {
            if (!startTimestamp) startTimestamp = timestamp;
            const progress = Math.min((timestamp - startTimestamp) / duration, 1);
            element.textContent = Math.floor(progress * (end - start) + start);
            if (progress < 1) {
                window.requestAnimationFrame(step);
            }
        };
        window.requestAnimationFrame(step);
    }

    // Check if elements are in viewport and start animation
    const observerOptions = {
        threshold: 0.5
    };

    const observer = new IntersectionObserver((entries) => {
        entries.forEach(entry => {
            if (entry.isIntersecting) {
                const element = entry.target;
                const finalValue = parseInt(element.textContent, 10);
                animateValue(element, 0, finalValue, 1500);
                observer.unobserve(element);
            }
        });
    }, observerOptions);

    statsNumbers.forEach(number => {
        observer.observe(number);
    });

    // Simulate loading chart data (for demo purposes)
    const mockBars = document.querySelectorAll('.mock-bar');

    if (mockBars.length > 0) {
        mockBars.forEach(bar => {
            const originalHeight = bar.style.height;
            bar.style.height = '0';

            setTimeout(() => {
                bar.style.height = originalHeight;
            }, 300);
        });
    }

    // Toggle between monthly and yearly data in charts (for demo purposes)
    const monthlyRadio = document.getElementById('monthly');
    const yearlyRadio = document.getElementById('yearly');

    if (monthlyRadio && yearlyRadio) {
        monthlyRadio.addEventListener('change', updateChartData);
        yearlyRadio.addEventListener('change', updateChartData);
    }

    function updateChartData() {
        // This would fetch new data in a real app
        // For demo, we'll just animate the bars again

        // Reset heights first
        mockBars.forEach(bar => {
            bar.style.height = '0';
        });

        // Set new random heights after a short delay
        setTimeout(() => {
            mockBars.forEach(bar => {
                const newHeight = Math.floor(Math.random() * 70) + 20 + '%';
                bar.style.height = newHeight;
            });
        }, 300);
    }

    // Initialize tooltips and popovers
    const tooltipTriggerList = document.querySelectorAll('[data-bs-toggle="tooltip"]');
    const tooltipList = [...tooltipTriggerList].map(el => new bootstrap.Tooltip(el));

    const popoverTriggerList = document.querySelectorAll('[data-bs-toggle="popover"]');
    const popoverList = [...popoverTriggerList].map(el => new bootstrap.Popover(el));
});