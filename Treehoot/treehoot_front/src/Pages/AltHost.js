import React, { useEffect, useState } from "react";
import "../styles.css";
import { Link } from "react-router-dom";

export default function AltHost() {
    const [game, setGame] = useState([]);
    const [activeTab, setActiveTab] = useState('tab1'); // New state for active tab
  
    const fetchGame = async () => {
      const response = await fetch("https://localhost:7219/api/Quiz");
      const data = await response.json();
      setGame(data);
      console.log(data);
    };
  
    useEffect(() => {
      fetchGame();
    }, []);
  
    // Function to render the game list
    const renderAvailableQuizList = () => (
      <div className="scroll-box-content">
        {game.map((quiz) => (
          <div key={quiz.id}>
            <div className="fs-3">{quiz.name}</div>
            <div className="d-flex flex-row align-items-start fs-6 mb-3">
              {quiz.description}
            </div>
          </div>
        ))}
      </div>
    );

       // Function to render the game list
       const renderHostedQuizList = () => (
        <div className="scroll-box-content">
          {game.map((quiz) => (
            <div key={quiz.id}>
              <div className="fs-3">{quiz.name}</div>
              <div className="d-flex flex-row align-items-start fs-6 mb-3">
                {quiz.description}
              </div>
            </div>
          ))}
        </div>
      );
  
    return (
      <div className="d-flex flex-column vh-100 justify-content-center align-items-center">
        <div className="tabs">
          <button className="btn host-join-button btn-outline-primary" onClick={() => setActiveTab('tab1')}>Tab 1</button>
          <button className={`tab-button ${activeTab === 'tab2' ? 'active' : ''}`} onClick={() => setActiveTab('tab2')}>Tab 2</button>
        </div>
        <div className="text fs-3 mb-3">Select your game:</div>
        <div className="scroll-box">
          {activeTab === 'tab1' && renderAvailableQuizList()}
          {activeTab === 'tab2' && renderHostedQuizList()} {/* You can customize this for different content */}
        </div>
        <div className="text fs-3 mt-1">Or</div>
        <div>
          <Link
            to="/new-game"
            className="new-game-button mt-3 btn btn-outline-primary fs-3 "
          >
            Create new Game
          </Link>
        </div>
      </div>
    );
  }