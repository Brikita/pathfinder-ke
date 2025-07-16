import Container from "@mui/material/Container";
import Typography from "@mui/material/Typography";
import Box from "@mui/material/Box";
import styled from "styled-components";
import { Link } from "react-router-dom";
import Footer from "../components/Footer.jsx";

const Discover = () => {
  return (
    <StyledWrapper>
      <div className="back-wrapper">
        <Link to="/" className="back-button">← Back</Link>
      </div>

      <Container maxWidth="md">
        <Box className="content-box">
          <Typography variant="h4" component="h3" gutterBottom>
            What is PathFinder KE?
          </Typography>

          <Typography variant="body1" paragraph>
            PathFinder KE is your post-high school cheat code.
            It’s a uniquely Kenyan mobile and web app designed to help you navigate your next steps in life.
            Think of it as part game, part career simulator, and part decision-making coach, all wrapped into one immersive experience.
          </Typography>

          <Typography variant="body1" paragraph>
            You get to explore different academic and career paths by playing through story-driven scenarios based on real-life possibilities.
            Every choice you make leads to a different outcome, giving you a safe space to test decisions and see where they might take you.
            It’s not just about entertainment, it’s about building insight and confidence.
            You learn by doing, not just dreaming.
          </Typography>

          <Typography variant="body1" paragraph>
            Whether you're just out of high school, navigating university life, or still figuring things out,
            PathFinder KE helps you visualize what your future could look like, with you fully in control.
          </Typography>

          <Typography variant="h5" component="h5" gutterBottom>
            Why We Exist
          </Typography>

          <Typography variant="body1" paragraph>
            Finishing high school often leaves young people with more questions than answers.
            With limited access to mentorship, relatable guidance, or career exposure, many are left making high-stakes decisions without enough clarity.
          </Typography>

          <Typography variant="body1" paragraph>
            PathFinder KE exists to bridge that gap. It transforms the stress of uncertainty into an interactive journey of discovery.
            Instead of guessing your way through the future, you get to explore it with intention.
            Try out paths, understand your strengths, see how different choices play out and unlock a direction that actually fits you.
          </Typography>

          <Typography variant="h5" component="h5" gutterBottom>
            Our Mission:
          </Typography>

          <Typography variant="body1" paragraph>
            To empower Kenyan youth to take charge of their future by simulating
            real-world academic and career decisions in an engaging, gamified way.
          </Typography>
        </Box>
      </Container>

      <Footer />
    </StyledWrapper>
  );
};

export default Discover;


const StyledWrapper = styled.div`
  background-color: #001429;
  min-height: 100vh;
  color: white;
  font-family: "Fredoka", sans-serif;

  .MuiTypography-root {
    font-family: "Fredoka", sans-serif;
  }
  .MuiTypography-body1{
    font-size: 1.5rem;
  }
  
  .content-box {
    padding: 3rem;
    background: rgba(255, 255, 255, 0.03);
    border-radius: 10px;
  }

  h3, h4, h5 {
    color: #1ce6ff;
    font-size: 2.3rem;
    font-weight: 550;
  }

  .back-wrapper {
    display: flex;
    justify-content: flex-start;
    padding: 2rem;
    font-weight: 500;
  }

  .back-button {
    background-color: #002852;
    color: #00e4ff;
    padding: 0.75rem 1.5rem;
    font-weight: 500;
    border: none;
    border-radius: 50px;
    text-decoration: none;
    font-size: 1.5rem;
    transition: background-color 0.3s ease;
    position: fixed;
  }

  .back-button:hover {
    background-color: #009ace;
    color: #ffffff;
  }
`;

