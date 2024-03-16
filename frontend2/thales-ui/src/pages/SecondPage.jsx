import {useParams} from "react-router-dom";

const SecondPage = () => {
  const {country} = useParams();

  return (
    <div>
      <h1>Second Page</h1>
      <h2>{country}</h2>
    </div>
  )
}

export default SecondPage;