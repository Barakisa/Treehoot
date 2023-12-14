import React from "react";
import "../styles.css";
import { Link } from "react-router-dom";
export default function Play() {
  return (
    <div className="d-flex flex-column justify-content-center align-items-center vh-100">
      <div className="text-center mb-5">
        <Link
          to="/althost"
          className="btn host-join-button btn-outline-primary "
        >
          Host
        </Link>
      </div>
      <div className="text-center p-5 ">
        <Link to="/join" className="btn btn-outline-success host-join-button ">
          Join
        </Link>
      </div>
    </div>
  );
}
