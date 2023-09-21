import React, { useEffect, useState } from "react";

export default function Timer(props) {
  const [remainingTime, setRemainingTime] = useState(props.timeLeft);

  useEffect(() => {
    let timeInterval;
    if (remainingTime > 0) {
      timeInterval = setInterval(() => {
        setRemainingTime((prevRemainingTime) => prevRemainingTime - 1);
      }, 1000);
    }
    return () => {
      clearInterval(timeInterval);
    };
  }, [remainingTime]);

  return (
    <div className="d-flex flex-row justify-content-center align-items-center fs-2">
      <span className="material-icons me-3 fs-2">alarm</span>
      <span className="">{remainingTime}</span>
    </div>
  );
}
