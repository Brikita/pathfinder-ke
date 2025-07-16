import React, { useState, useEffect } from "react";
import styled from "styled-components";
import { motion } from "framer-motion";

const SliderGallery = ({ children, width = "12rem", height = "18rem" }) => {
  const cardCount = React.Children.count(children);
  const [isMobileOrTablet, setIsMobileOrTablet] = useState(false);

  useEffect(() => {
    const checkScreen = () => {
      setIsMobileOrTablet(window.innerWidth <= 1024);
    };
    checkScreen();
    window.addEventListener("resize", checkScreen);
    return () => window.removeEventListener("resize", checkScreen);
  }, []);

  const repeatedChildren = isMobileOrTablet ? children : [...children, ...children];

  return (
    <SliderWrapper
      style={{
        "--width": width,
        "--height": height,
        "--quantity": cardCount,
        "--duration": `${cardCount * 2.5}s`,
      }}
    >
      <motion.div
        className="slider-track"
        initial={{ opacity: 0, y: 100 }}
        whileInView={{ opacity: 1, y: 0 }}
        transition={{ duration: 1.5, ease: "easeIn" }}
      >
        {repeatedChildren.map((child, index) => (
          <div className="item" key={index}>
            {child}
          </div>
        ))}
      </motion.div>
    </SliderWrapper>
  );
};

export default SliderGallery;


const SliderWrapper = styled.div`
  width: 100%;
  height: 60vh;
  overflow: hidden;
  padding-top: 3rem;
  position: relative;
  mask-image: linear-gradient(to right, transparent, #000 10%, #000 90%, transparent);
  -webkit-mask-image: linear-gradient(to right, transparent, #000 10%, #000 90%, transparent);

  .slider-track {
    display: flex;
    width: max-content;
    animation: scroll var(--duration) linear infinite;
  }

.item {
  width: var(--width);
  height: var(--height);
  flex-shrink: 0;
  filter: grayscale(0);
  transition: filter 0.4s ease;
}

/* Pause animation and apply grayscale to all items on hover */
.slider-track:hover {
  animation-play-state: paused;
}

.slider-track:hover .item {
  filter: grayscale(1);
}

/* Cancel grayscale when hovering a specific item */
.slider-track:hover .item:hover {
  filter: grayscale(0) !important;
}

    

  @keyframes scroll {
    from {
      transform: translateX(0);
    }
    to {
       transform: translateX(calc(-1 * var(--width) * var(--quantity))); /* Scroll all cards */
    }
  }

  &:hover .slider-track {
    animation-play-state: paused;
  }

  @media (max-width: 1024px) {
  .slider-track .item {
    transform: scale(1.15);
    z-index: 2;
   }

  height: auto;

  .slider-track {
    display: grid;
    grid-template-columns: repeat(2, auto);
    animation: none;
    gap: 6rem; 
    justify-content: center;
    align-items: center;
      margin: auto;
  }

  .item {
    width: 100%;
    max-width: 16rem;
    margin: 0 auto;
  }
  
  .slider-track .item:first-child {
    grid-column: 1 / -1; /* Span across both columns */
    justify-self: center;
  }
}

@media (max-width: 480px) {
  .slider-track {
    display: grid;
    grid-template-columns: repeat(auto-fit, minmax(15rem, 1fr));
    gap: 0.2rem;
    justify-content: center;
    align-items: center;
    margin: auto;
    width: 100%;
  }

  .item {
    width: 100%;
    max-width: 17rem;
    margin: 0 auto;
  }
}


`;
