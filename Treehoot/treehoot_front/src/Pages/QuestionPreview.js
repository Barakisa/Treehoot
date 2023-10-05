import React, { useState } from "react";
import ProgressBar from "../components/ProgressBar";
import { useNavigate } from "react-router";
import "../styles.css";

export default function QuestionPreview() {
  const remainingTime = 7;
  const navigate = useNavigate();

  setTimeout(() => {
    navigate("/choose_topic");
  }, remainingTime * 1000 + 500);

  return (
    <div className="container text" style={{ height: "100vh" }}>
      <div className="row justify-content-center align-items-center text-center fs-1 py-5">
        Prepare to choose the topic for your next question!
      </div>
      <div className="row justify-content-center">
        <ProgressBar remainingTime={remainingTime} />
      </div>
    </div>
  );
}
