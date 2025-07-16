import React, { useEffect, useState } from 'react';
import '../style.css';

const navLinks = [
    { label: 'Home', section: 'home-section' },
    { label: 'About', section: 'about-section' },
    { label: 'Team', section: 'team-section' },
    { label: 'Contact', section: 'contact-section' },
];

const NavBar = ({ onNavClick }) => {
  const [activeSection, setActiveSection] = useState('home-section');
  const [menuOpen, setMenuOpen] = useState(false);

  useEffect(() => {
    const observer = new IntersectionObserver(
      (entries) => {
        const visible = entries.find((entry) => entry.isIntersecting);
        if (visible) setActiveSection(visible.target.id);
      },
      { threshold: 0.1 }
    );

    navLinks.forEach((link) => {
      const section = document.getElementById(link.section);
      if (section) observer.observe(section);
    });

    return () => observer.disconnect();
  }, []);

  return (
    <>
      <header className="header">
        {/* Logo */}
        <a
          href="home-section"
          className="header__logo"
          onClick={(e) => {
            e.preventDefault();
            onNavClick('home-section');
          }}
        >
          <img src="/logo1.svg" alt="PathFinder Logo" className="nav-logo" />
        </a>

        {/* Desktop Nav */}
        <nav className="navbar">
          <ul className="navbar__menu">
            {navLinks.map((link) => (
              <li className="navbar__item" key={link.section}>
                <a
                  href={`#${link.section}`}
                  className={`navbar__link ${activeSection === link.section ? 'active' : ''}`}
                  onClick={(e) => {
                    e.preventDefault();
                    onNavClick(link.section);
                  }}
                >
                  {link.label}
                </a>
              </li>
            ))}
          </ul>
        </nav>

        {/* Mobile Toggle Icons */}
        {!menuOpen && (
         <button className="menu-icon" onClick={() => setMenuOpen(true)}>
            <i className="bi bi-list"></i>
         </button>
         )}
         </header>

      {/* ✅ Move this outside header to break out of limited height */}
      <div className={`mobile-wrapper ${menuOpen ? 'open' : ''}`}>
          <button className="close-icon" onClick={() => setMenuOpen(false)}>
            <i className="bi bi-x"></i>
          </button>
        <ul>
          {navLinks.map((link) => (
            <li key={link.section}>
              <a
                href={`#${link.section}`}
                onClick={(e) => {
                  e.preventDefault();
                  onNavClick(link.section);
                  setMenuOpen(false);
                }}
              >
                {link.label}
              </a>
            </li>
          ))}
        </ul>
      </div>
    </>
  );
};

export default NavBar;
