import { React, useState } from "react";
import { Link, useNavigate } from "react-router-dom";
import { useUser } from "../UserContext";

const EMAIL_REGEX = /^[^\s@]+@[^\s@]+\.[^\s@]+$/;
const PASSWORD_REGEX = /^(?=.*[A-Za-z])(?=.*\d)[A-Za-z\d]{8,}$/;

export default function LogIn() {
  const [email, setEmail] = useState({ email: "", isValid: true });
  const [password, setPassword] = useState({ password: "", isValid: true });
  const { user, login } = useUser();

  const navigate = useNavigate();

  const handleEmailChange = (e) => {
    setEmail({
      email: e.target.value,
      isValid: EMAIL_REGEX.test(e.target.value),
    });
  };

  const handlePasswordChange = (e) => {
    setPassword({
      password: e.target.value,
      isValid: PASSWORD_REGEX.test(e.target.value),
    });
  };

  const handleSubmit = async (e) => {
    e.preventDefault();

    try {
      const url = "https://localhost:7219/api/User/login";
      const options = {
        method: "POST",
        headers: {
          "Content-Type": "application/json",
        },
        body: JSON.stringify({
          email: email.email,
          password: password.password,
        }),
      };

      const res = await fetch(url, options);
      const resData = await res.json();
      if (res.ok && resData.success) {
        console.log("loggedin");
        login({ username: resData.username, isLoggedIn: resData.success });
        navigate("/");
      } else {
        console.log("login failed");
      }
    } catch (err) {
      console.error(err);
    }
  };

  return (
    <div className="d-flex flex-column justify-content-center align-items-center vh-100">
      <div className="border border-1 p-5 rounded" style={{ width: "500px" }}>
        <div className="d-flex flex-row justify-content-center mb-5">
          <span className="fs-1 block">Log in</span>
        </div>

        <div>
          <form onSubmit={(e) => handleSubmit(e)}>
            <div className="mb-3">
              <label for="exampleInputEmail1" className="form-label">
                Email address
              </label>
              <input
                type="email"
                className="form-control"
                id="exampleInputEmail1"
                aria-describedby="emailHelp"
                value={email.email}
                onChange={(e) => handleEmailChange(e)}
              />
              <div
                id="emailHelp"
                className={`form-text ${
                  email.isValid ? "text-warning" : "text-danger"
                }`}
              >
                {email.isValid
                  ? "We'll never share your email with anyone else."
                  : "Invalid email adress."}
              </div>
            </div>
            <div className="mb-3">
              <label for="exampleInputPassword1" className="form-label">
                Password
              </label>
              <input
                type="password"
                className="form-control"
                id="exampleInputPassword1"
                value={password.password}
                onChange={(e) => handlePasswordChange(e)}
              />
              {password.isValid ? (
                ""
              ) : (
                <span className="form-text text-danger">
                  Password should be minimum length of 8 characters, atleast one
                  digit and letter is required!
                </span>
              )}
            </div>
            <div className="mb-3 form-check">
              <input
                type="checkbox"
                className="form-check-input"
                id="exampleCheck1"
              />
              <label className="form-check-label" for="exampleCheck1">
                Remember me!
              </label>
            </div>
            <div className="d-flex flex-column align-items-center gap-3">
              <button type="submit" className="btn btn-lg btn-primary mt-2">
                Log me in
              </button>
              <Link to="/register">
                Don't have an account? Click here and register!
              </Link>
            </div>
          </form>
        </div>
      </div>
    </div>
  );
}
