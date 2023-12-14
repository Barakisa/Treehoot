import React, { useState } from "react";
import { Link } from "react-router-dom";

const EMAIL_REGEX = /^[^\s@]+@[^\s@]+\.[^\s@]+$/;
const PASSWORD_REGEX = /^(?=.*[A-Za-z])(?=.*\d)[A-Za-z\d]{8,}$/;

export default function RegisterPage() {
  const [email, setEmail] = useState({ email: " ", isValid: true });
  const [nickname, setNickname] = useState({ nickname: "", isValid: true });
  const [password, setPassword] = useState({ password: "", isValid: true });
  const [repeatPassword, setRepeatPassword] = useState({
    repeatPassword: "",
    isValid: true,
  });
  const [responseMsg, setResponseMsg] = useState({ sucess: "", message: "" });
  const [isRegistered, setIsRegistered] = useState(false);

  const handleEmailChange = (e) => {
    setEmail((prevEmail) => ({
      ...prevEmail,
      email: e.target.value,
      isValid: EMAIL_REGEX.test(e.target.value),
    }));
  };
  const handleNickNameChange = (e) => {
    setNickname((prevNickname) => ({
      ...prevNickname,
      nickname: e.target.value,
      isValid: e.target.value.length > 3,
    }));
  };

  const handlePasswordChange = (e) => {
    setPassword((prevPassword) => ({
      ...prevPassword,
      password: e.target.value,
      isValid: PASSWORD_REGEX.test(e.target.value),
    }));
  };

  const handleRepeatPasswordChange = (e) => {
    setRepeatPassword((prevRepeatPassword) => ({
      ...prevRepeatPassword,
      repeatPassword: e.target.value,
      isValid: e.target.value === password.password,
    }));
  };

  const SubmitRegistration = async (e) => {
    e.preventDefault();

    if (
      email.isValid &&
      nickname.isValid &&
      password.isValid &&
      repeatPassword.isValid
    ) {
      try {
        const url = "https://localhost:7219/api/User/register/";
        const options = {
          method: "POST",
          headers: {
            "Content-Type": "application/json",
          },
          body: JSON.stringify({
            username: nickname.nickname,
            email: email.email,
            password: password.password,
          }),
        };

        const res = await fetch(url, options);
        const resData = await res.json();
        console.log(resData);

        if (res.ok) {
          setEmail({ email: "", isValid: true });
          setNickname({ nickname: "", isValid: true });
          setPassword({ password: "", isValid: true });
          setRepeatPassword({ repeatPassword: "", isValid: true });
          setResponseMsg({
            success: resData.Success,
            message: resData.Message,
          });
          setIsRegistered(true);
        } else {
          setResponseMsg({
            success: resData.Success,
            message: resData.Message,
          });
          setIsRegistered(false);
        }
      } catch (err) {
        console.error("error:", err);
      }
    }
  };

  return (
    <div className="d-flex flex-column justify-content-center align-items-center vh-100">
      <div className="border border-1 p-5 rounded" style={{ width: "500px" }}>
        <div className="d-flex flex-row justify-content-center mb-5">
          <span className="fs-1 block">Register</span>
        </div>
        <form onSubmit={(e) => SubmitRegistration(e)}>
          <div class="mb-3">
            <label for="exampleInputEmail1" class="form-label">
              Email address
            </label>
            <input
              type="email"
              class="form-control"
              id="exampleInputEmail1"
              aria-describedby="emailHelp"
              value={email.email}
              onChange={(e) => handleEmailChange(e)}
              required
            />
            <div
              id="emailHelp"
              className={email.isValid ? `text-warning` : `text-danger`}
            >
              <span>
                {email.isValid
                  ? "We'll never share your email with anyone else."
                  : "Invalid Email adress"}
              </span>
            </div>
          </div>
          <div class="mb-3">
            <label for="exampleInputPassword1" class="form-label">
              Nickname
            </label>
            <input
              type="input"
              class="form-control"
              id="exampleInputPassword1"
              value={nickname.nickname}
              onChange={(e) => handleNickNameChange(e)}
              required
            />
            {nickname.isValid ? (
              ""
            ) : (
              <span className="text-danger form-text">
                Nickname must be more than 3 characters.
              </span>
            )}
          </div>
          <div class="mb-3">
            <label for="exampleInputPassword1" class="form-label">
              Password
            </label>
            <input
              type="password"
              class="form-control"
              id="exampleInputPassword1"
              value={password.password}
              onChange={(e) => handlePasswordChange(e)}
              required
            />
            {password.isValid ? (
              ""
            ) : (
              <span className="text-danger form-text">
                Password should be minimum length of 8 characters, atleast one
                digit and letter is required
              </span>
            )}
          </div>
          <div class="mb-4">
            <label for="exampleInputPassword1" class="form-label">
              Repeat Password
            </label>
            <input
              type="password"
              class="form-control"
              id="exampleInputPassword1"
              value={repeatPassword.repeatPassword}
              onChange={(e) => handleRepeatPasswordChange(e)}
              required
            />
            {repeatPassword.isValid ? (
              ""
            ) : (
              <span className="text-danger form-text">
                Both passwords should match.
              </span>
            )}
          </div>
          <div className="d-flex flex-column justify-content-center">
            <button type="submit" className="btn btn-lg btn-primary w-full">
              Register me!
            </button>
            <div className="text-center mt-2">
              <span
                className={responseMsg.success ? "text-success" : "text-danger"}
              >
                {responseMsg.success === false ? (
                  responseMsg.Message
                ) : isRegistered ? (
                  <Link to="/log-in">Go to login page</Link>
                ) : (
                  ""
                )}
              </span>
            </div>
          </div>
        </form>
      </div>
    </div>
  );
}
