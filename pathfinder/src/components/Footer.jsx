import React from "react";
import Container from "@mui/material/Container";
import Typography from "@mui/material/Typography";
import Box from "@mui/material/Box";
import styled from "styled-components";

const Footer = () => (
  <StyledFooter component="footer">
    <Container maxWidth="lg" className="footer-content">
      <div className="footer-top">
        <div className="brand">
          <h3>Pathfinder-KE</h3>
          <p>Play Your Path. Own Your Future.</p>
        </div>

        <div className="partners">
          <h4>Partners</h4>
          <div className="partner-logos">
            <a href="https://www.jkuat.ac.ke/" target="_blank" rel="noopener noreferrer" className="jkuat-logo">
              <img src="/JKUAT.png" alt="JKUAT"/></a>
            <a href="https://jhubafrica.com/" target="_blank" rel="noopener noreferrer" className="jhub-logo">
              <img src="/JHUB-logo.webp" alt="JHUB"/></a>
          </div>
        </div>
      </div>

      <div className="footer-bottom">
        <ul className="footer-socials">
          <li>
            <a href="https://www.tiktok.com/@pathfinderke_" target="_blank" rel="noopener noreferrer">
              <i className="bi bi-tiktok" />
            </a>
          </li>
          <li>
            <a href="https://x.com/PathFinderke_" target="_blank" rel="noopener noreferrer">
              <i className="bi bi-twitter-x" />
            </a>
          </li>
        </ul>
        <Typography variant="body2" className="footer-text">
          © {new Date().getFullYear()} Pathfinder-KE. All rights reserved.
        </Typography>
      </div>
    </Container>
  </StyledFooter>
);

export default Footer;

const StyledFooter = styled(Box)`
  background-color: #062147; 
  color: #fff;
  width: 100%;
  height: 40vh;
  padding: 4rem 1rem 2rem 1rem;
  position: relative;
  z-index: 1;
  overflow: hidden;
  isolation: isolate;

  .footer-content {
    max-width: 1200px;
    margin: 0 auto;
    display: flex;
    flex-direction: column;
    gap: 2.5rem;
  }

  .footer-top {
    display: flex;
    justify-content: space-between;
    align-items: flex-start;
    flex-wrap: wrap;
    gap: 2rem;
  }

  .brand h3 {
    font-family: "Deltha", sans-serif;
    font-size: 2rem;
    color: #1ce6ff;
    margin-bottom: 0.5rem;
  }

  .brand p {
    font-family: "Deltha", sans-serif;
    font-size: 1rem;
    color: #ccc;
  }
  
  .partners{
    text-align: center;
  }

  .partners h4 {
    font-size: 1.7rem;
    color: #00eaff;
    margin-bottom: 0.8rem;
  }

  .partner-logos {
    display: flex;
    gap: 1.5rem;
    flex-wrap: wrap;
    justify-content: center;
  }

  .jkuat-logo img,
  .jhub-logo img {
    width: 90px;
    height: 90px;
    display: flex;
    justify-content: center;
    align-items: center;
  }
  
  .jhub-logo img {
    width: 150px;
  }
  
  .partner-logos a{
    transition: transform 0.3s cubic-bezier(0.34, 1.56, 0.64, 2), color 0.3s ease;
  }
  
  .partner-logos a:hover{
    transform: scale(1.1);
  }
  
  

  .footer-bottom {
    border-top: 1px solid #333;
    padding-top: 1.5rem;
    display: flex;
    flex-direction: column;
    align-items: center;
    text-align: center;
    justify-content: space-between;
    gap: 1rem;
    flex-wrap: wrap;
  }

  .footer-socials {
    display: flex;
    gap: 1.5rem;
    list-style: none;
    padding: 0;
    margin: 0;
  }

  .footer-socials li a {
  color: #00eaff;
  font-size: 1.5rem;
  transition: transform 0.3s cubic-bezier(0.3, 1.56, 0.64, 3), color 0.3s ease;
  display: inline-block;
}

.footer-socials li a:hover {
  color: #22ff00;
  transform: scale(1.3);
}


  .footer-text {
    color: #aaa;
    font-size: 0.85rem;
  }
  
  @media (max-width: 1024px) {
  height: 20vh;
  padding: 1.5rem 0;
  display: flex;
  flex-direction: column;
  justify-content: flex-end;

  .footer-content {
    gap: 1.5rem;
  }

  .footer-top {
    gap: 1rem; 
  }

  .brand h3 {
    margin-bottom: 0.3rem; 
  }

  .partners h4 {
    margin-bottom: 0.5rem; 
  }

  .partner-logos {
    gap: 1rem; 
  }

  .footer-bottom {
    gap: 0.5rem;
    padding-top: 1rem; 
  }
}
  

  @media (max-width: 480px) {
  padding: 2rem 0;
  height: auto;

  .footer-content {
    width: 100%;
    margin: auto;
    padding: 0;
    box-sizing: border-box;
    display: flex;
    flex-direction: column;
    align-items: center;
  }

  .footer-top {
    flex-direction: column;
    text-align: center;
    align-items: center;
  }

  .footer-bottom {
    flex-direction: column;
    text-align: center;
    align-items: center;
  }

  .partner-logos {
    justify-content: center;
  }
}
`;


