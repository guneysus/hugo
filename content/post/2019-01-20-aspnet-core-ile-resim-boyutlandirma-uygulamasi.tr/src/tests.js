var should = require("chai").should(),
  expect = require("chai").expect,
  supertest = require("supertest"),
  API_URL = "http://app:5000",
  api = supertest(API_URL);

describe("JPEG File Upload", function() {
  it("single JPEG file upload", function(done) {
    api
      .post("/api/upload")
      .set("Content-Type", "multipart/form-data")
      .attach("image", "_data/ZY-IMG_0091-635px.jpg")
      .expect(200)
      .expect("Content-Type", /text\/plain/)
      .expect(/jpg/)
      .end(function(err, res) {
        if (err) {
          return done(err);
        }
        uploadedfile = res.text;

        done();
      });
  });
});