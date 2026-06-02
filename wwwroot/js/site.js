// ─── Page Transition (green wave + logo) ────────────────────────────────────
(function () {
    const overlay = document.getElementById('page-transition');
    if (!overlay) return;

    // Sayfa açılışında overlay'i geri çek
    window.addEventListener('load', () => {
        setTimeout(() => overlay.classList.add('sweep-out'), 50);
    });

    document.addEventListener('click', e => {
        const a = e.target.closest('a');
        if (!a) return;
        const href = a.getAttribute('href');
        if (!href || href.startsWith('#') || href.startsWith('mailto') ||
            href.startsWith('tel') || a.target === '_blank' ||
            a.hasAttribute('download') || href.startsWith('javascript')) return;
        e.preventDefault();
        // 1. Dalga süpürür içeri (0-400ms)
        overlay.classList.remove('sweep-out');
        overlay.classList.add('sweep-in');
        // 2. Logo belirir (gecikme CSS ile 200ms)
        // 3. 900ms sonra yeni sayfaya git
        setTimeout(() => { window.location.href = href; }, 900);
    });
})();

// ─── Navbar Scroll ──────────────────────────────────────────────────────────
(function () {
    const nav = document.getElementById('main-navbar');
    if (!nav) return;
    const onScroll = () => nav.classList.toggle('scrolled', window.scrollY > 60);
    window.addEventListener('scroll', onScroll, { passive: true });
    onScroll();
})();

// ─── Mobile Menu Close on Outside Click ─────────────────────────────────────
(function () {
    const toggler = document.querySelector('.navbar-toggler');
    const collapse = document.querySelector('.navbar-collapse');
    if (!toggler || !collapse) return;
    document.addEventListener('click', e => {
        if (!collapse.contains(e.target) && !toggler.contains(e.target)) {
            collapse.classList.remove('show');
        }
    });
})();

// ─── Counter Animation ──────────────────────────────────────────────────────
(function () {
    const counters = document.querySelectorAll('.stat-num[data-target]');
    if (!counters.length) return;

    const animate = el => {
        const target = parseInt(el.dataset.target, 10);
        const duration = 2000;
        const step = target / (duration / 16);
        let current = 0;
        const tick = () => {
            current = Math.min(current + step, target);
            el.textContent = Math.floor(current) + (el.dataset.suffix || '');
            if (current < target) requestAnimationFrame(tick);
        };
        requestAnimationFrame(tick);
    };

    const observer = new IntersectionObserver(entries => {
        entries.forEach(en => {
            if (en.isIntersecting) {
                animate(en.target);
                observer.unobserve(en.target);
            }
        });
    }, { threshold: 0.5 });

    counters.forEach(c => observer.observe(c));
})();

// ─── Scroll Reveal ──────────────────────────────────────────────────────────
(function () {
    const els = document.querySelectorAll('.reveal');
    if (!els.length) return;
    const observer = new IntersectionObserver(entries => {
        entries.forEach(en => {
            if (en.isIntersecting) {
                en.target.classList.add('visible');
                observer.unobserve(en.target);
            }
        });
    }, { threshold: 0.15 });
    els.forEach(el => observer.observe(el));
})();

// ─── Project Category Filter ────────────────────────────────────────────────
(function () {
    const btns = document.querySelectorAll('.kategori-btn');
    const cards = document.querySelectorAll('.proje-kart-wrap');
    if (!btns.length) return;

    btns.forEach(btn => {
        btn.addEventListener('click', () => {
            btns.forEach(b => b.classList.remove('active'));
            btn.classList.add('active');
            const kat = btn.dataset.kategori;
            cards.forEach(card => {
                const match = !kat || card.dataset.kategori === kat;
                card.style.display = match ? '' : 'none';
            });
        });
    });
})();

// ─── Before/After Slider ────────────────────────────────────────────────────
(function () {
    const wraps = document.querySelectorAll('.before-after-wrap');
    wraps.forEach(wrap => {
        const handle = wrap.querySelector('.ba-handle');
        const after = wrap.querySelector('.img-after');
        if (!handle || !after) return;

        let dragging = false;

        const setPos = clientX => {
            const rect = wrap.getBoundingClientRect();
            let pct = ((clientX - rect.left) / rect.width) * 100;
            pct = Math.max(5, Math.min(95, pct));
            after.style.clipPath = `inset(0 0 0 ${pct}%)`;
            handle.style.left = pct + '%';
        };

        handle.addEventListener('mousedown', e => { dragging = true; e.preventDefault(); });
        handle.addEventListener('touchstart', () => { dragging = true; }, { passive: true });

        document.addEventListener('mousemove', e => { if (dragging) setPos(e.clientX); });
        document.addEventListener('touchmove', e => {
            if (dragging) setPos(e.touches[0].clientX);
        }, { passive: true });

        document.addEventListener('mouseup', () => dragging = false);
        document.addEventListener('touchend', () => dragging = false);
    });
})();

// ─── Thumbnail Slider ───────────────────────────────────────────────────────
(function () {
    const sliders = document.querySelectorAll('.thumb-slider');
    sliders.forEach(slider => {
        const track = slider.querySelector('.thumb-track');
        const prevBtn = slider.querySelector('.thumb-prev');
        const nextBtn = slider.querySelector('.thumb-next');
        if (!track) return;

        const itemWidth = () => (track.querySelector('.thumb-item')?.offsetWidth || 300) + 20;
        let pos = 0;

        const clamp = val => {
            const max = Math.max(0, track.scrollWidth - track.parentElement.offsetWidth);
            return Math.max(0, Math.min(val, max));
        };

        prevBtn?.addEventListener('click', () => {
            pos = clamp(pos - itemWidth() * 2);
            track.style.transform = `translateX(-${pos}px)`;
        });
        nextBtn?.addEventListener('click', () => {
            pos = clamp(pos + itemWidth() * 2);
            track.style.transform = `translateX(-${pos}px)`;
        });
    });
})();

// ─── Referans Auto-Slider ───────────────────────────────────────────────────
(function () {
    const carousel = document.querySelector('.referans-carousel');
    if (!carousel) return;

    const track = carousel.querySelector('.referans-track');
    const cards = carousel.querySelectorAll('.referans-kart');
    const dots = carousel.querySelectorAll('.ref-dot');
    if (!cards.length) return;

    let current = 0;
    let timer;

    const goTo = idx => {
        current = (idx + cards.length) % cards.length;
        track.style.transform = `translateX(-${current * 100}%)`;
        dots.forEach((d, i) => d.classList.toggle('active', i === current));
    };

    const start = () => { timer = setInterval(() => goTo(current + 1), 4000); };
    const stop = () => clearInterval(timer);

    dots.forEach((d, i) => d.addEventListener('click', () => { stop(); goTo(i); start(); }));
    carousel.querySelector('.ref-prev')?.addEventListener('click', () => { stop(); goTo(current - 1); start(); });
    carousel.querySelector('.ref-next')?.addEventListener('click', () => { stop(); goTo(current + 1); start(); });
    carousel.addEventListener('mouseenter', stop);
    carousel.addEventListener('mouseleave', start);
    start();
})();

// ─── SSS Accordion ──────────────────────────────────────────────────────────
(function () {
    const btns = document.querySelectorAll('.sss-btn');
    btns.forEach(btn => {
        btn.addEventListener('click', () => {
            const answer = btn.nextElementSibling;
            const isOpen = btn.classList.contains('open');

            document.querySelectorAll('.sss-btn.open').forEach(b => {
                b.classList.remove('open');
                b.nextElementSibling.style.maxHeight = null;
            });

            if (!isOpen) {
                btn.classList.add('open');
                answer.style.maxHeight = answer.scrollHeight + 'px';
            }
        });
    });
})();

// ─── Gallery Lightbox ───────────────────────────────────────────────────────
(function () {
    const items = document.querySelectorAll('[data-lightbox]');
    if (!items.length) return;

    const lb = document.createElement('div');
    lb.id = 'lightbox';
    lb.innerHTML = `
        <div class="lb-overlay"></div>
        <div class="lb-content">
            <button class="lb-close">&times;</button>
            <button class="lb-prev">&#8592;</button>
            <img class="lb-img" src="" alt="">
            <button class="lb-next">&#8594;</button>
        </div>`;
    document.body.appendChild(lb);

    const img = lb.querySelector('.lb-img');
    let images = [];
    let idx = 0;

    const show = i => {
        idx = (i + images.length) % images.length;
        img.src = images[idx];
        lb.classList.add('open');
        document.body.style.overflow = 'hidden';
    };
    const hide = () => { lb.classList.remove('open'); document.body.style.overflow = ''; };

    items.forEach((el, i) => {
        el.style.cursor = 'zoom-in';
        el.addEventListener('click', () => {
            images = Array.from(items).map(e => e.dataset.lightbox || e.src || e.href);
            show(i);
        });
    });

    lb.querySelector('.lb-close').addEventListener('click', hide);
    lb.querySelector('.lb-overlay').addEventListener('click', hide);
    lb.querySelector('.lb-prev').addEventListener('click', () => show(idx - 1));
    lb.querySelector('.lb-next').addEventListener('click', () => show(idx + 1));

    document.addEventListener('keydown', e => {
        if (!lb.classList.contains('open')) return;
        if (e.key === 'Escape') hide();
        if (e.key === 'ArrowLeft') show(idx - 1);
        if (e.key === 'ArrowRight') show(idx + 1);
    });
})();

// ─── Character Counter ──────────────────────────────────────────────────────
(function () {
    document.querySelectorAll('textarea[maxlength]').forEach(ta => {
        const counter = ta.parentElement.querySelector('.char-counter');
        if (!counter) return;
        const max = parseInt(ta.maxLength, 10);
        const update = () => counter.textContent = `${ta.value.length} / ${max}`;
        ta.addEventListener('input', update);
        update();
    });
})();

// ─── KVKK Cookie Banner ─────────────────────────────────────────────────────
(function () {
    const bar = document.getElementById('kvkk-bar');
    if (!bar) return;
    if (localStorage.getItem('kvkk_accepted')) { bar.style.display = 'none'; return; }
    bar.style.display = 'flex';
    bar.querySelector('#kvkk-accept')?.addEventListener('click', () => {
        localStorage.setItem('kvkk_accepted', '1');
        bar.style.opacity = '0';
        setTimeout(() => bar.style.display = 'none', 400);
    });
})();

// ─── WhatsApp Tooltip ───────────────────────────────────────────────────────
(function () {
    const btn = document.querySelector('.whatsapp-float');
    if (!btn) return;
    // 3 saniye sonra tooltip'i bir kez göster, 4s sonra gizle
    setTimeout(() => {
        btn.classList.add('show-tooltip');
        setTimeout(() => btn.classList.remove('show-tooltip'), 4000);
    }, 3000);
    btn.addEventListener('mouseenter', () => btn.classList.add('show-tooltip'));
    btn.addEventListener('mouseleave', () => btn.classList.remove('show-tooltip'));
})();

// ─── Smooth Scroll for Anchor Links ─────────────────────────────────────────
(function () {
    document.querySelectorAll('a[href^="#"]').forEach(anchor => {
        anchor.addEventListener('click', e => {
            const target = document.querySelector(anchor.getAttribute('href'));
            if (target) {
                e.preventDefault();
                target.scrollIntoView({ behavior: 'smooth', block: 'start' });
            }
        });
    });
})();

// ─── Blog Reading Time ───────────────────────────────────────────────────────
(function () {
    const icerikDiv = document.getElementById('blogIcerik');
    const okumaSuresiEl = document.getElementById('okumaSuresi');
    if (icerikDiv && okumaSuresiEl) {
        const kelimeSayisi = icerikDiv.innerText.trim().split(/\s+/).length;
        okumaSuresiEl.textContent = Math.max(1, Math.ceil(kelimeSayisi / 200));
    }
})();

// ─── Form Validation ────────────────────────────────────────────────────────
(function () {
    document.querySelectorAll('.needs-validation').forEach(form => {
        form.addEventListener('submit', e => {
            if (!form.checkValidity()) {
                e.preventDefault();
                e.stopPropagation();
            }
            form.classList.add('was-validated');
        });
    });
})();
