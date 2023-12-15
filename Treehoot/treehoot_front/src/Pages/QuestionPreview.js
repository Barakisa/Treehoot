import React, { useEffect, useState } from "react";
import ProgressBar from "../components/ProgressBar";
import { useNavigate } from "react-router";
import "../styles.css";

export default function QuestionPreview(props) {
  const remainingTime = 3;
  const navigate = useNavigate();

  useEffect(() => {
    const timeoutId = setTimeout(() => {
      navigate("/choose_topic");
    }, remainingTime * 1000 + 500);

    return () => {
      clearTimeout(timeoutId);
    };
  }, []);

  return (
    <div className="container text" style={{ height: "100vh", marginTop: 50 }}>
      <div className="row justify-content-center align-items-center text-center fs-1 py-5">
        Prepare to choose the topic for your next question!
      </div>
      <div className="row justify-content-center">
        <ProgressBar remainingTime={remainingTime} />
      </div>
    </div>
  );
}
