workflow "Build" {
  on = "commit"
  resolves = ["Build Hugo"]
}

action "Build Hugo" {
  uses = "lowply/build-hugo@master"
  runs = "hugo"
}
