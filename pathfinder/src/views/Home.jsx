import React, { useState, useEffect } from "react";
import Typography from "@mui/material/Typography";
import Box from "@mui/material/Box";
import Button from "@mui/material/Button";
import styled from "styled-components";
import { motion } from "framer-motion";



const Home = () => {
  const [showPopup, setShowPopup] = useState(false);

  useEffect(() => {
  window.scrollTo(0, 0);
}, []);


  return (
    <StyledWrapper>
      <Box className="home-container">
        <motion.div
          className="text-section"
          initial={{ opacity: 0, x: -150 }}
          whileInView={{ opacity: 1, x: 0 }}
          viewport={{ once: true, amount: 0.2 }}
          transition={{ duration: 1.2 }}
        >
          <div className="text-container">
            <Typography variant="h2" component="h1" gutterBottom className="home-title">
              PathFinder-KE
            </Typography>
            <Typography variant="h5" className="home-subtitle">
              Play Your Path. Own Your Future.
            </Typography>
            <div
              className="home-buttons">
              <Button
                component="a"
                href="#"
                className="animated-btn"
                onClick={(e) => {
                  e.preventDefault();
                  setShowPopup(true);
                }}
              >
                <span className="btn-label"><i className="bi bi-controller"></i> EXPLORE</span>
              </Button>
            </div>
          </div>
        </motion.div>

        <motion.div
          className="avatar-wrapper"
          initial={{ opacity: 0, x: 100 }}
          whileInView={{ opacity: 1, x: 0 }}
          viewport={{ once: true, amount: 0.2 }}
          transition={{ duration: 1 }}
        >
          <div className="avatar-container">
            <img src="/avatar.png" alt="Avatar Character" />
          </div>
        </motion.div>

        {showPopup && (
          <div className="popup" onClick={() => setShowPopup(false)}>
            <div className="popup-content" onClick={(e) => e.stopPropagation()}>
              <span className="popup-close" onClick={() => setShowPopup(false)}>
                &times;
              </span>
              <h2>🛠️ Oops... Not Quite Ready!</h2>
              <p>The CareerVerse is under construction. The devs are currently googling “how to make a game.” 💻✨</p>
            </div>
          </div>
        )}
      </Box>
    </StyledWrapper>
  );
};

export default Home;


const StyledWrapper = styled.div.attrs(() => ({
  id: "home", // Ensures anchor #home works
  className: "section" // Optional class if you're using it globally
}))`
  scroll-margin-top: 80px;

  @media (max-width: 1024px) {
    scroll-margin-top: 200px;
  }


  .home-container {
    display: flex;
    flex-wrap: wrap;
    gap: 0.5rem;
    padding: 1rem 2rem;
    min-height: 100vh;
    justify-content: space-between;
    align-items: center;
  }

  .text-container {
    display: flex;
    flex-direction: column;
    justify-content: center;
    flex: 1;
    padding: 0 4rem 4rem 4rem;
  }
  
  .home-title {
    font-family: "Deltha", sans-serif;
    font-weight: 400;
    font-size: 4.5rem;
  }

  .home-subtitle {
    font-family: "Deltha", sans-serif;
    font-size: 1.75rem;
    font-style: italic;
    color: #1ce6ff;
  }

  .home-buttons {
    margin-top: 3rem;
    display: inline-flex;
    max-width: fit-content;
    white-space: nowrap;
    padding: 5px;
    border-radius: 90px;
    position: relative;
    background: linear-gradient(120deg, #000f20 10%, #002852 30%, #005288 60%, #004daa 90%);
    background-size: 300% 300%;
    animation: gradientFlow 2s ease infinite;
    animation-direction: normal;
    transition: transform 0.3s ease, box-shadow 0.3s ease, animation-direction 0.3s ease;
    overflow: hidden;
    color: #fff;
    z-index: 1;
  }

  @keyframes gradientFlow {
    0% { background-position: 0 50%; }
    50% { background-position: 100% 50%; }
    100% { background-position: 0 50%; }
  }

  .home-buttons:hover {
    width: auto;
    transform: scale(1.05);
    animation-direction: reverse;
  }

  .home-buttons:active {
    transform: scale(0.8);
  }

  .animated-btn {
    position: relative;
    z-index: 1;
    background: transparent;
    border: none;
    padding: 0;
    color: white;
    display: flex;
    align-items: center;
    gap: 0.5rem;
    cursor: pointer;
    transition: all 0.4s ease;
    text-decoration: none;
    max-width: 100%;
  }

  .animated-btn .btn-label::after {
    content: ' the careerverse';
    position: absolute;
    top: 0;
    left: 36%;
    white-space: nowrap;
    opacity: 0;
    transform: translateX(0.6rem);
    transition: opacity 0.7s ease, transform 0.7s ease;
  }

  .animated-btn:hover .btn-label {
    padding-right: 17rem;
  }

  .animated-btn:hover .btn-label::after {
    opacity: 1;
    transform: translateX(0);
    padding: 0.5rem;
  }

  .animated-btn:hover span {
    transform: scale(1);
  }

  .animated-btn span {
    display: flex;
    font-size: 1.25rem;
    font-weight: 600;
    color: white;
    align-items: center;
    gap: 0.5rem;
    transition: 0.4s ease-in-out;
    font-family: "Audiowide", sans-serif;
    padding: 0.5rem;
  }

  .avatar-wrapper {
    display: flex;
    justify-content: flex-end;
    align-items: center;
    flex: 1;
    padding: 2rem;
  }

  .avatar-container {
    display: flex;
    align-items: center;
  }

  .avatar-container img {
    height: 95vh;
    width: auto;
    object-fit: contain;
  }

  @media (max-width: 1024px) {
    .home-container {
      flex-direction: column;
      padding: 2rem 1rem;
      align-items: center;
    }
    
   .text-container {
    text-align: center;
    display: flex;
    flex-direction: column;
    align-items: center;
  
}



    .home-title {
      font-size: 5rem;
    }

    .home-subtitle {
      font-size: 2rem;
      margin-top: 0.5rem;
    }

    .home-buttons {
      margin-top: 2rem;
    }

    .avatar-wrapper {
      justify-content: center;
      padding: 1rem 0;
    }

    .avatar-container img {
      max-height: 60vh;
    }

    .animated-btn span {
      font-size: 1.8rem;
    }

    .animated-btn .btn-label::after {
      display: none;
    }

    .animated-btn:hover .btn-label {
      padding-right: 0;
    }
  }

  @media (max-width: 480px) {  
    .text-section {
  display: flex;
  flex-direction: column;
  align-items: center;
  padding: 1rem;
  text-align: center;
  width: 100%;
}

.text-container {
  padding: 0;
  margin: 0 auto;
  max-width: 90%;
  display: flex;
  flex-direction: column;
  align-items: center;
  text-align: center;
}

    
    .home-title {
      font-size: 2.7rem !important;
    }

    .home-subtitle {
      font-size: 1.55rem !important;
    }

    .home-buttons {
      margin-top: 1rem;
    }

    .animated-btn span {
      font-size: 1.1rem;
    }
    .avatar-container img {
      max-height: 65vh;
    }
}

  }
`;
