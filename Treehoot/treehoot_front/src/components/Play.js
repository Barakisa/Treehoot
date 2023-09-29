import React from "react";
import "./styles.css";
export default function Play() {
  return (
    <div className="d-flex flex-column justify-content-center align-items-center vh-100">
      <div className="text-center mb-5">
        <button className="btn host-join-button btn-outline-primary ">
          Host
        </button>
      </div>
      <div className="text-center p-5 ">
        <button className="btn btn-outline-success host-join-button ">
          Join
        </button>
      </div>
    </div>
  );
}
