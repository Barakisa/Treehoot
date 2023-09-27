import React, { useState, useEffect } from "react";

export default function ProgressBar(props) {
  const [remainingTime, setRemainingTime] = useState(10 * props.remainingTime);

  useEffect(() => {
    const intervalId = setInterval(() => {
      setRemainingTime((prevRemainingTime) => {
        if (prevRemainingTime === 0) {
          return 0;
        } else {
          return prevRemainingTime - 1;
        }
      });
    }, 100);
    return () => {
      clearInterval(intervalId);
    };
  }, []);

  return (
    <div className="d-flex flex-column w-50">
      <div
        className="progress border border-black border-2"
        role="progressbar"
        aria-valuenow={remainingTime}
        aria-valuemin="0"
        aria-valuemax="100"
        style={{ height: "25px" }}
      >
        <div
          className="progress-bar progress-bar-striped progress-bar-animated bg-danger"
          style={{
            width: `${(remainingTime / (10 * props.remainingTime)) * 100}%`,
          }}
        ></div>
      </div>
    </div>
  );
}
