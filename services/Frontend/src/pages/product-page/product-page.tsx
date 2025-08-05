import { useSearchParams } from "react-router-dom";

export const ProductPage = () => {
  const [searchParams] = useSearchParams();
  const query = searchParams.get("id");

  return (
    <>
      <h1>ProductPage: {query}</h1>
    </>
  );
};
