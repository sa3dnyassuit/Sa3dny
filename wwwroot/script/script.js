document.addEventListener('DOMContentLoaded', () => {
    // Handle Register button click
    const registerBtn = document.querySelector('.btn-register');
    if (registerBtn) {
        registerBtn.addEventListener('click', () => {
            alert('Redirecting to Registration Page...');
        });
    }

    // Handle Login button click
    const loginBtn = document.querySelector('.btn-login');
    if (loginBtn) {
        loginBtn.addEventListener('click', () => {
            alert('Redirecting to Login Page...');
        });
    }

    // Handle Subscribe button click
    const subscribeBtn = document.querySelector('.footer-subscribe button');
    const subscribeInput = document.querySelector('.footer-subscribe input');
    if (subscribeBtn && subscribeInput) {
        subscribeBtn.addEventListener('click', () => {
            const email = subscribeInput.value;
            if (email && email.includes('@')) {
                alert(`Thank you for subscribing with: ${email}`);
                subscribeInput.value = '';
            } else {
                alert('Please enter a valid email address.');
            }
        });
    }

    // Smooth scroll for navigation links
    const navLinks = document.querySelectorAll('.nav-links a');
    navLinks.forEach(link => {
        link.addEventListener('click', (e) => {
            // Only prevent default if it's an internal link
            if (link.getAttribute('href').startsWith('#')) {
                e.preventDefault();
                const targetId = link.getAttribute('href');
                if (targetId !== '#') {
                    const targetElement = document.querySelector(targetId);
                    if (targetElement) {
                        targetElement.scrollIntoView({ behavior: 'smooth' });
                    }
                }
            }
        });
    });

    // Simple animation on scroll for service cards
    const observerOptions = {
        threshold: 0.1
    };

    const observer = new IntersectionObserver((entries) => {
        entries.forEach(entry => {
            if (entry.isIntersecting) {
                entry.target.style.opacity = '1';
                entry.target.style.transform = 'translateY(0)';
            }
        });
    }, observerOptions);

    const serviceCards = document.querySelectorAll('.service-card');
    serviceCards.forEach(card => {
        card.style.opacity = '0';
        card.style.transform = 'translateY(20px)';
        card.style.transition = 'opacity 0.6s ease-out, transform 0.6s ease-out';
        observer.observe(card);
    });
});
const cards = document.querySelectorAll(".hero-card");
const carousel = document.getElementById("heroCarousel");

const radius = 250;
const total = cards.length;

cards.forEach((card,i)=>{

  const angle = (360/total)*i;

  card.style.transform = `
    rotateY(${angle}deg)
    translateZ(${radius}px)
  `;

});

let index = 0;

function rotate(){

  index++;

  carousel.style.transform = `rotateY(${-index*(360/total)}deg)`;

  cards.forEach(c=>c.classList.remove("active"));

  cards[index % total].classList.add("active");

}

if(cards.length > 0){
  cards[0].classList.add("active");
  setInterval(rotate,2000);
}


function openServiceForm(serviceName) {
  const overlay = document.getElementById("serviceFormOverlay");
  const title = document.getElementById("selectedServiceTitle");
  const serviceInput = document.getElementById("serviceName");

  if (overlay && title && serviceInput) {
    overlay.style.display = "flex";
    title.innerText = serviceName + " Request";
    serviceInput.value = serviceName;
  }
}

function closeServiceForm() {
  const overlay = document.getElementById("serviceFormOverlay");
  if (overlay) {
    overlay.style.display = "none";
  }
}

const serviceRequestForm = document.getElementById("serviceRequestForm");

if (serviceRequestForm) {
  serviceRequestForm.addEventListener("submit", function(e) {
    e.preventDefault();

    const service = document.getElementById("serviceName").value;
    const problem = document.getElementById("problemDetails").value;
    const address = document.getElementById("address").value;
    const phone = document.getElementById("phone").value;

   window.location.href = "../pages/request-success.html";
    this.reset();
    closeServiceForm();
  });
}
// Nums Counter
const counters = document.querySelectorAll('.counter');
const labels = document.querySelectorAll('.stat-label');
let finishedCounters = 0;

const startCounting = (el) => {
    const target = +el.getAttribute('data-target');
    let current = 0;
    
    const updateCount = () => {
        const increment = target / 50; 
        if (current < target) {
            current += increment;
            el.innerText = Math.ceil(current);
            setTimeout(updateCount, 30);
        } else {
            el.innerText = target;
            finishedCounters++;
            // لما الأربعة يخلصوا
            if (finishedCounters === counters.length) {
                labels.forEach((label, i) => {
                    setTimeout(() => label.classList.add('show-all'), i * 150);
                });
            }
        }
    };
    updateCount();
};

const observer = new IntersectionObserver((entries) => {
    entries.forEach(entry => {[]
        if (entry.isIntersecting) {
            finishedCounters = 0;
            labels.forEach(l => l.classList.remove('show-all'));
            startCounting(entry.target);
        }
    });
}, { threshold: 0.7 });

counters.forEach(c => observer.observe(c));

