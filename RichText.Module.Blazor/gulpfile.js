const { src, dest } = require('gulp');
const { series } = require('gulp');
const spawn = require('child_process').spawn;
const fs = require('fs');

function installModules(cb) {
  spawn('npm', ['install'], {
    cwd: 'node_modules/devexpress-richedit/',
    stdio: 'inherit',
    shell: true,
  }).on('close', function (code) {
    cb(code);
  });
}
function buildRich(cb) {
  if (
    !fs.existsSync(
      'node_modules/devexpress-richedit/dist/custom/dx.richedit.min.js'
    )
  ) {
    spawn('npm', ['run build-custom'], {
      cwd: 'node_modules/devexpress-richedit/',
      stdio: 'inherit',
      shell: true,
    }).on('close', function (code) {
      cb(code);
    });
  } else {
    cb();
  }
}
function copy(source, destination) {
  return src(source).pipe(dest(destination));
}
function copyRichJS() {
  return copy(
    'node_modules/devexpress-richedit/dist/custom/dx.richedit.min.js',
    'wwwroot'
  );
}
function copyRichCSS() {
  return copy(
    'node_modules/devexpress-richedit/dist/custom/dx.richedit.css',
    'wwwroot'
  );
}
function copyRichIcons() {
  return copy(
    'node_modules/devexpress-richedit/dist/custom/icons/**/*',
    'wwwroot/icons'
  );
}
exports.default = series(
  installModules,
  buildRich,
  copyRichJS,
  copyRichCSS,
  copyRichIcons
);
