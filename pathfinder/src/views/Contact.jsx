import React, { useState } from 'react';
import styled from 'styled-components';
import 'bootstrap-icons/font/bootstrap-icons.css';
import Footer from '../components/Footer';
import { motion } from "framer-motion";

const fadeInAnimationVariants = {
  initial: { opacity: 0, y: 100 },
  animate: (index) => ({
    opacity: 1,
    y: 0,
    transition: {
      delay: 0.05 * index,
      duration: 1,
      ease: "easeOut"
    }
  })
};

const Contact = () => {
  return (
    <StyledWrapper>
      <div className="contact-content">
        <div className="contact-container">
          <div className="contact-left">
            <motion.div className="text-wrapper"
            variants={fadeInAnimationVariants}
            initial="initial"
            whileInView="animate">
              <h2>Join the CareerVerse Today</h2>
              <p>Reach us through:</p>
              <ul>
                <li><a href="tel:+254768751223" className="hover-underline-animation"><i className="bi bi-telephone-fill"></i> +254 768 751 223</a></li>
                <li><a href="mailto:pathfinderke29@gmail.com" className="hover-underline-animation"><i className="bi bi-envelope-fill"></i> pathfinderke29@gmail.com</a></li>
                <li><a href="#" className="hover-underline-animation"><i className="bi bi-geo-fill"></i> Juja, Kiambu County</a></li>
              </ul>
            </motion.div>
          </div>
        </div>
      </div>
    </StyledWrapper>
  );
};

export default Contact;

const StyledWrapper = styled.div`
  background: url("/game-bg.jpg") no-repeat center center fixed;
  background-size: cover;
  min-height: 100vh;
  display: flex;
  flex-direction: column;
  justify-content: space-between;

  .contact-content {
    flex: 1;
    display: flex;
    align-items: center;
  }

  .contact-container {
    flex: 1;
    display: flex;
    justify-content: flex-start;
    padding: 4rem 6rem;
  }

  .contact-left {
    flex: 1;
    display: flex;
    align-items: center;
  }

  .text-wrapper {
    max-width: 500px;
    color: #ffffff;
  }

  .contact-left h2 {
    font-size: 2.5rem;
    margin-bottom: 1rem;
    color: #1ce6ff;
  }

  .contact-left ul {
    list-style: none;
    padding: 0;
    margin-bottom: 2rem;
  }

  .contact-left li {
    display: flex;
    align-items: center;
    gap: 1rem;
    margin: 1rem 0;
    font-size: 1.2rem;
  }

  .contact-left li i {
    font-size: 1.3rem;
    color: #0077b5;
  }

  .contact-left li a {
    text-decoration: none;
    color: #ffffff;
  }

  @media (max-width: 768px) {
    .contact-container {
      padding: 2rem;
      justify-content: center;
    }
    .text-wrapper {
      text-align: center;
    }
    .text-wrapper h2{
      -webkit-text-stroke-width: 0.1px;
      -webkit-text-stroke-color: #fff;
    }
  }

  .hover-underline-animation {
    display: inline-block;
    position: relative;
  }

  .hover-underline-animation::after {
    content: '';
    position: absolute;
    width: 100%;
    transform: scaleX(0);
    height: 2px;
    bottom: -2px;
    left: 0;
    background-color: #1ce6ff;
    transform-origin: bottom right;
    transition: transform 0.4s ease-out;
    border-radius: 20px;
  }

  .hover-underline-animation:hover::after {
    transform: scaleX(1);
    transform-origin: bottom left;
  }
`;
