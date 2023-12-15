import React from "react";
import { useState } from "react";
import { useQuiz } from "../QuizContext";
import { Link, useNavigate } from "react-router-dom";
import { useUser } from "../UserContext";

export default function Score() {
  const { user } = useUser();

  return (
    <div className="d-flex flex-column justify-content-center align-items-center vh-100">
      <span className="fs-1 p-4">You answered correctly: {user.score} </span>
      <div>
        <Link to="/" className="text-bold fs-2">
          Go home
        </Link>
      </div>
    </div>
  );
}
