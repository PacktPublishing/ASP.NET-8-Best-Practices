/// <binding BeforeBuild='build' />
const { series } = require('gulp');

// Packages defined at the top
const gulp = require('gulp'),
      gp_clean = require('gulp-clean'),
      path = require('path'),
      tsConfig = require("gulp-typescript"),
      uglify = require("gulp-uglify-es").default,
      source = require('vinyl-source-stream'),
      buffer = require("vinyl-buffer"),
      rename = require("gulp-rename"),
      browserify = require("browserify"),
      gp_sass = require('gulp-sass')(require("sass"));

// define our paths for our app
const basePath = path.resolve(__dirname, "wwwroot");
const moduleSource = path.resolve(__dirname, "node_modules");

const tsProject = tsConfig.createProject(path.resolve(basePath, 'tsconfig.json'));
const tsSource = path.resolve(basePath, "src");
const sassSource = path.resolve(basePath, "scss");
const libSource = path.resolve(basePath, "lib");

const srcPaths = {
    js: [
        path.resolve(tsSource, '**/*.js') // all *.js in every folder
    ],
    jsBundles: [
        path.resolve(tsSource, 'site.js') // specific files to bundle/minify
    ],
    sassSrc: [
        path.resolve(sassSource, 'site.scss')
    ],
    // local dev (copy dist into lib)
    lib: [
        {
            src: path.resolve(moduleSource, 'bootstrap/dist/**/*'),
            dest: path.resolve(libSource, 'bootstrap/')
        },
        {
            src: path.resolve(moduleSource, '@fortawesome/fontawesome-free/**/*'),
            dest: path.resolve(libSource, 'fontawesome/')
        }
    ]
};

const destPaths = {
    jsFolder: path.resolve(basePath, 'js'), // wwwroot/js
    cssFolder: path.resolve(basePath, 'css') // wwwroot/css
};

// Tasks (no cleanup for Hello World)
function testTask(done) {
    console.log('Hello World! We finished a task!');
    done();
}

/* Copy Libraries to their location */
function copyLibraries(done) {
    srcPaths.lib.forEach(item => {
        return gulp.src(item.src)
            .pipe(gulp.dest(item.dest));
    });
    done();
}

function cleanLibraries(done) {
    srcPaths.lib.forEach(item => {
        return gulp.src(item.dest + "/*.*")
            .pipe(gp_clean({ force: true }));
    });
    done();
}

/* TypeScript */
function ts_transpile(done) {
    tsProject
        .src()
        .pipe(tsProject()).js
        .pipe(gulp.dest(tsSource));
    done();
}

function ts_clean(done) {
    gulp.src(srcPaths.js, { allowEmpty: true })
        .pipe(gp_clean({ force: true }));
    done();
}

/* JavaScript */
function js_bundle_min(done) {

    srcPaths.jsBundles.forEach(file => {

        const b = browserify({
            entries: file, // Only need initial file, browserify finds the deps
            debug: true, // Enable sourcemaps
            transform: [['babelify', { 'presets': ["es2015"] }]]
        });

        b.bundle()
            .pipe(source(path.basename(file)))
            .pipe(rename(path => {
                path.basename += ".min";
                path.extname = ".js";
            }))
            .pipe(buffer())
            .pipe(uglify())
            .pipe(gulp.dest(destPaths.jsFolder));
        done();
    });
}

function js_clean(done) {
    gulp.src(path.resolve(destPaths.jsFolder, '**/*.js'), { read: false })
        .pipe(gp_clean({ force: true }));
    done();
}

/* SASS/CSS */
function sass_clean(done) {
    gulp.src(destPaths.cssFolder + "*.*", { read: false })
        .pipe(gp_clean({ force: true }));
    done();
}

function sass(done) {
    gulp.src(srcPaths.sassSrc)
        .pipe(gp_sass({ outputStyle: 'compressed' }))
        .pipe(rename({
            suffix: '.min'
        }))
        .pipe(gulp.dest(destPaths.cssFolder));
    done();
}


// Global default and cleanup tasks
exports.build = series(
    cleanLibraries,
    copyLibraries,
    ts_clean,
    js_clean,
    sass_clean,
    ts_transpile,
    js_bundle_min,
    sass
);
