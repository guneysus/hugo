workflow "Build" {
  on = "push"
  resolves = ["Build Hugo"]
}

action "Build Hugo" {
  uses = "lowply/build-hugo@master"
  runs = "hugo"
}
