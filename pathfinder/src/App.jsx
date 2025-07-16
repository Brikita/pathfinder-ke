import React, { useRef } from "react";
import {BrowserRouter as Router, Routes, Route, useLocation} from "react-router-dom";
import NavBar from "./components/NavBar";
import About from "./views/About";
import Contact from "./views/Contact";
import Home from "./views/Home";
import Team from "./views/Team";
import Discover from "./views/Discover";
import Footer from "./components/Footer";
import "./style.css";
import "bootstrap-icons/font/bootstrap-icons.css";
import ScrollToTop from "./components/ScrollToTop";

// This must stay outside
function App() {
  return (
    <Router>
      <ScrollToTop />
      <AppRoutes />
    </Router>
  );
}

// This runs inside Router context
function AppRoutes() {
  const location = useLocation();
  const homeRef = useRef(null);
  const aboutRef = useRef(null);
  const teamRef = useRef(null);
  const contactRef = useRef(null);
  const footerRef = useRef(null);



  const handleNavClick = (section) => {
    const refs = {
      "home-section": homeRef,
      "about-section": aboutRef,
      "team-section": teamRef,
      "contact-section": contactRef,
    };
    refs[section]?.current?.scrollIntoView({ behavior: "smooth" });
  };

  const isDiscoverPage = location.pathname === "/discover";

  return (
    <>
      {!isDiscoverPage && <NavBar onNavClick={handleNavClick} />}
      <Routes location={location}>
        <Route
          path="/"
          element={
            <main className="page-content">
              <section ref={homeRef} id="home-section" className="section">
                <Home />
              </section>
              <section ref={aboutRef} id="about-section" className="section">
                <About />
              </section>
              <section ref={teamRef} id="team-section" className="section">
                <Team />
              </section>
              <section ref={contactRef} id="contact-section" className="section">
                <Contact />
              </section>
              <section ref={footerRef} id="footer-section">
                <Footer />
              </section>
            </main>
          }
        />
        <Route path="/discover" element={<Discover />} />
      </Routes>
    </>
  );
}

export default App;
