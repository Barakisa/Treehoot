import React, { useEffect, useState } from "react";
import ProgressBar from "../components/ProgressBar";

export default function QuestionPreview() {
  return (
    <div className="container justify-content-center">
      <div className="col-12">
        <div className="row justify-content-center text-center fs-1 py-5">
          Prepare to choose the topic for your next question!
        </div>
        <div className="row justify-content-center">
          <ProgressBar remainingTime={7} />
        </div>
      </div>
    </div>
  );
}
